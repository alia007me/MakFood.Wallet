using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline;
using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOnline;
using MakFood.Wallet.Application.CommandHandlers.ChefApprove;
using MakFood.Wallet.Domain.Model.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakFood.Wallet.Host.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class ChargeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IChargeWalletRepository _chargeRepository;

        public ChargeController(IMediator mediator, IChargeWalletRepository chargeRepository)
        {
            _mediator = mediator;
            _chargeRepository = chargeRepository;
        }

        [HttpPatch("Wallet/{walletId}/Balance/Increase/Online")]
        public async Task<IActionResult> ChargeWallet([FromBody]ChargeBalanceOnlineCommand chargeBalanceOnline)
        {
            chargeBalanceOnline.Validate();


            var result = await _mediator.Send(chargeBalanceOnline);
            return Ok(result);

        }
        [HttpPost("Wallet/{walletId}/Balance/Increase/Offline")]
        public async Task<IActionResult> ChargeOfflineWallet([FromBody] ChargeBalanceOfflineCommand chargeBalanceOffline)
        {
            chargeBalanceOffline.Validate();



            var result = await _mediator.Send(chargeBalanceOffline);
            return Ok(result);
        }
        [HttpPatch("Wallet/{walletId}/Balance/Increase/Approve")]
        public async Task<IActionResult> ChefApprove([FromBody] ChefApproveCommand chefApprove)
        {

            chefApprove.Validate();
            var result = await _mediator.Send(chefApprove);
            return Ok(result);
        }
    }
}
