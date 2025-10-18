using MakFood.Wallet.Application.QueryHandlers.Transaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MakFood.Wallet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TranslationOfTransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TranslationOfTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(Guid WalletId, [FromQuery] DateTime dateTime)
        {
            
            var query = new TranslationOfTransactionQuery
            {
                WalletId = WalletId,
                dateTime = dateTime
            };

            var result = await _mediator.Send(query);

            if (result == null || result.transactionItems.Count == 0)
                return NotFound("NotFound");

            return Ok(result); 
        }
    }
}