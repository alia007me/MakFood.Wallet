using Azure.Core;
using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline;
using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOnline;
using MakFood.Wallet.Application.CommandHandlers.ChefApprove;
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
        public async Task<IActionResult> ChargeWallet([FromBody] ChargeBalanceOnlineWriteDto chargeBalance, CancellationToken ct)
        {
            var validator = new ChargeBalanceOnlineCommandValidator();
            var OnlineCommand = new ChargeBalanceOnlineCommand() { Write = chargeBalance };
            OnlineCommand.Write.CancellationToken = ct;
            var validationResult = validator.Validate(OnlineCommand);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new Exception(errors);
            }
            var result = await _mediator.Send(OnlineCommand);
            if (result.Result == "Invalid")
                return BadRequest(result.Result);
            //var redirectUrl = $"https://sandbox.zarinpal.com/pg/StartPay/{result}";
            return Ok(new { authority = result.Result, redirectUrl = $"https://sandbox.zarinpal.com/pg/StartPay/{result.Result}" });

            //return Redirect(redirectUrl);

        }
        [HttpPost("ChargeBalanceOffline")]
        public IActionResult ChargeWalletOffline([FromBody] ChargeBalanceOfflineWriteDto chargeBalance, CancellationToken ct)
        {
            var OfflineCommand = new ChargeBalanceOfflineCommand { request = chargeBalance };
            OfflineCommand.request.CancellationToken = ct;
            var Validator  = new ChargeBalanceOfflineCommandValidator();
            var ValidatorResult = Validator.Validate(OfflineCommand);
            if (!ValidatorResult.IsValid)
            {
                var errors = string.Join(", ", ValidatorResult.Errors.Select(e => e.ErrorMessage));
                throw new Exception(errors);
            }

            var result = _mediator.Send(OfflineCommand);
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
        public async Task<IActionResult> ChefResponseToARequest([FromBody] ChefResponseDto chargeBalance, CancellationToken ct)
        {
            var ChefApproveCommand = new ChefApproveCommand { Amount = chargeBalance.Amount, DateTime = chargeBalance.DateTime, Walletid = chargeBalance.Walletid ,cancellationToken = ct};
            var Validator = new ChefApproveCommandValidator();
            var ValidationResult = Validator.Validate(ChefApproveCommand);
            if (!ValidationResult.IsValid)
            {
                var errors = string.Join(',', ValidationResult.Errors.Select(x => x.ErrorMessage));
                throw new Exception(errors);
            }
            var result = await _mediator.Send(ChefApproveCommand);
            if (result.Message.Contains("Your Current Balance"))
                return Ok(result.Message);
            else
            {
                return BadRequest(result.Message);
            }





            /*var result = await _chargeRepository.CheckChefResponseAsync(chargeBalance);
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
            }*/


        }
        

    }
    
    
}
