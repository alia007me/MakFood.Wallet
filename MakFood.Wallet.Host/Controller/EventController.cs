using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline;
using MakFood.Wallet.Application.CommandHandlers.RobertInaroAzAvalBiar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakFood.Wallet.Host.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase 
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPatch("Wallet/{walletid}/ReplayWallet")]
        public async Task<IActionResult> ReplayWallet([FromBody] RobertInaroAzAvalBiarCommand command)
        {
            command.Validate();

            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
