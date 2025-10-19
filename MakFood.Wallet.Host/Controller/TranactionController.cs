using MakFood.Wallet.Application.QueryHandlers.Transaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MakFood.Wallet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("wallet/{walletId}")]
        public async Task<IActionResult> GetTransactions(Guid walletId, [FromQuery] DateTime dateTime)
        {
            var query = new ShowTransactionQuery
            {
                WalletId = walletId,
                dateTime = dateTime, 
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}