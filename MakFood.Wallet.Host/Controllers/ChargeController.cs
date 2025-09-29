using MakFood.Wallet.Application.DTOs.ChargeBalanceDTO;
using MakFood.Wallet.Application.Features.ChargeBalance.Request.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakFood.Wallet.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChargeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChargeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("ChargeBalance")]
        public async Task<IActionResult> ChargeWallet([FromBody]ChargeBalanceWriteDTO chargeBalance)
        {
            var result = await _mediator.Send(new ChargeBalanceOnlineRequest { Write = chargeBalance });
            if (result == "Invalid")
                return BadRequest(result);
            //var redirectUrl = $"https://sandbox.zarinpal.com/pg/StartPay/{result}";
            return Ok(new { authority = result, redirectUrl = $"https://sandbox.zarinpal.com/pg/StartPay/{result}" });

            //return Redirect(redirectUrl);

        }
    }
}
