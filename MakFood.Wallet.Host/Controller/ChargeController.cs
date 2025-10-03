using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOnline;
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

        [HttpPost("ChargeBalanceOnline")]
        public async Task<IActionResult> ChargeWallet([FromBody]ChargeBalanceOnlineCommand chargeBalanceOnline)
        {
            var result = await _mediator.Send(chargeBalanceOnline);
            return Ok(result);

        }

    }
}
