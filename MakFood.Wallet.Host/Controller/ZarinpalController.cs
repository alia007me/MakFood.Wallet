using MakFood.Wallet.Application.CommandHandlers.ZarinpalPayRequest;
using MakFood.Wallet.Application.CommandHandlers.ZarinpalVerify;
using MakFood.Wallet.Application.ServiceContracts;
using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakFood.Wallet.Host.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class ZarinpalController : ControllerBase
    {
        private readonly IZarinpalGateway _gateway;
        private readonly IWalletRepository _chargeRepository;
        private readonly IHttpClientFactory _clientFactory;
        private readonly MakFoodWalletDbContext _context;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _merchent_id = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX";


        public ZarinpalController(IZarinpalGateway gateway, IWalletRepository chargeRepository, IHttpClientFactory clientFactory, MakFoodWalletDbContext context, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _gateway = gateway;
            _chargeRepository = chargeRepository;
            _clientFactory = clientFactory;
            _context = context;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("request")]
        public async Task<IActionResult> PaymentRequest(ZarinpalPayRequestCommand requestDTO)
        {

            var result = await _mediator.Send(requestDTO);
            return Redirect(result.PayPath);

        }
        [HttpGet("verify")]
        public async Task<IActionResult> Verify([FromQuery] string authority, [FromQuery] string status,CancellationToken ct)
        {




            var request = new ZarinpalVerifyCommand() { authority = authority, merchant_id = _merchent_id ,status = status  };


            var result = await _mediator.Send(request);
            if (result.message.Contains("SuccessFully"))
            {
                await _unitOfWork.Commit(ct);
                return Ok(result.message);

            }

            else if(result.message.Contains("Cancelled")) {
                await _unitOfWork.Commit(ct);
                return BadRequest(result.message);
            }
            else
            {
                return BadRequest(result.message);

            }




        }


    }
    
}
