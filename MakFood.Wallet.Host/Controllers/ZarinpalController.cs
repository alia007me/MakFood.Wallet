using MakFood.Wallet.Application.Contracts;
using MakFood.Wallet.Application.DTOs.ZarinpalGatewayDTOs;
using MakFood.Wallet.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MakFood.Wallet.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZarinpalController : ControllerBase
    {
        private readonly IZarinpalGateway _gateway;
        private readonly IChargeRepository _chargeRepository;
        private readonly IHttpClientFactory _clientFactory;
        private readonly MakFoodWalletDbContext _context;
        private readonly string _merchent_id = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX";


        public ZarinpalController(IZarinpalGateway gateway, IChargeRepository chargeRepository , IHttpClientFactory clientFactory ,MakFoodWalletDbContext context)
        {
            _gateway = gateway;
            _chargeRepository = chargeRepository;
            _clientFactory = clientFactory;
            _context = context;
        }

        [HttpGet("request")]
        public async Task<IActionResult> PaymentRequest(ZarinpalRequestDTO requestDTO)
        {
            var result = await _gateway.PayRequest(requestDTO.Amount, requestDTO.Email, requestDTO.description);

            if (result.data.code == 100)
            {


                var authority = result.data.authority;
                var redirectUrl = $"https://sandbox.zarinpal.com/pg/StartPay/{authority}";
                return Redirect(redirectUrl);

            }
            return BadRequest(result);
        }
        [HttpGet("verify")]
        public async Task<IActionResult> Verify([FromQuery] string authority, [FromQuery] string status)
        {
            var transaction = await _context.ChargeTransactions.SingleOrDefaultAsync(x => x.TransactionNumber == authority);
            if (status != "OK" || transaction == null)
                return BadRequest("پرداخت لغو شد یا ناموفق بود");

            var client = _clientFactory.CreateClient();

            var verifyRequest = new ZarinpalVerify
            {
                merchant_id = _merchent_id,
                authority = authority,
                amount = Convert.ToInt32(transaction.TransactionAmount)
            };

            var response = await client.PostAsJsonAsync("https://sandbox.zarinpal.com/pg/v4/payment/verify.json", verifyRequest);
            var result = await response.Content.ReadFromJsonAsync<ZarinpalVerifyResponse>();

            if (result?.data.code == 100) 
            {
                var wallet = await _context.Wallets.SingleOrDefaultAsync(x => x.WalletId == transaction.WalletId);
                if (wallet != null)
                {
                    wallet.IncreaseBalance(transaction.TransactionAmount);
                    await _context.SaveChangesAsync();
                }
                transaction.UpdateTransactionNumber(Convert.ToString(result.data.ref_id));
                await _context.SaveChangesAsync();
                return Ok($"SuccessFull Pay , TransactionNumber : {result.data.ref_id}");
            }

            return BadRequest($"Payment Lost , Error Code: {result?.data.code}");
        }


    }
}
