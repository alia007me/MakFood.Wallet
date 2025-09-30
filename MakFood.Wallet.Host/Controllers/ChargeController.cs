using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline;
using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOnline;
using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Dtos;
using MakFood.Wallet.Domain.Model.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MakFood.Wallet.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChargeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IChargeRepository _chargeRepository;

        public ChargeController(IMediator mediator , IChargeRepository chargeRepository)
        {
            _mediator = mediator;
            _chargeRepository = chargeRepository;
        }

        [HttpPost("ChargeBalanceOnline")]
        public async Task<IActionResult> ChargeWallet([FromBody] ChargeBalanceOnlineWriteDto chargeBalance)
        {
            var result = await _mediator.Send(new ChargeBalanceOnlineCommand { Write = chargeBalance });
            if (result.Result == "Invalid")
                return BadRequest(result.Result);
            //var redirectUrl = $"https://sandbox.zarinpal.com/pg/StartPay/{result}";
            return Ok(new { authority = result.Result, redirectUrl = $"https://sandbox.zarinpal.com/pg/StartPay/{result.Result}" });

            //return Redirect(redirectUrl);

        }
        [HttpPost("ChargeBalanceOffline")]
        public IActionResult ChargeWalletOffline([FromBody] ChargeBalanceOfflineWriteDto chargeBalance)
        {
            var result = _mediator.Send(new ChargeBalanceOfflineCommand { request = chargeBalance });
            if(result.Result.Response == "Please Wait Until Chef Accept Your Payment")
            {
                return Ok(result.Result.Response);
            }
            else
            {
                return BadRequest(result.Result.Response);
            }
        }
        [HttpPost("ChefResponse")]
        public async Task<IActionResult> ChefResponseToARequest([FromBody] ChefResponseDto chargeBalance)
        {
            var result = await _chargeRepository.CheckChefResponseAsync(chargeBalance);
            if(result == "Wallet Not Found")
            {
                return BadRequest("Wallet Not Found");
            }
            else if(result.Contains("Your Current Balance"))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }


        }
        

    }
    
    
}
