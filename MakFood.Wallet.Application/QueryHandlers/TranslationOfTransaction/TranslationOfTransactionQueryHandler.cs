using MakFood.Wallet.Domain.Model.Contracts;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.QueryHandlers.Transaction
{
    public class TranslationOfTransactionQueryHandler
        : IRequestHandler<TranslationOfTransactionQuery, TranslationOfTransactionQueryResponse>
    {
        private readonly ITransactionRepository _transactionRepository;

        public TranslationOfTransactionQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<TranslationOfTransactionQueryResponse> Handle(
            TranslationOfTransactionQuery request,
            CancellationToken cancellationToken)
        {
           
            var transactions = await _transactionRepository.GetTransaction(request.WalletId, request.dateTime);

            var transactionItems = transactions.Select(c => new TranslationOfTransactionQueryResponse.TransactionItem
            {
                
                WalletId = c.WalletId,
                dateTime = c.DateTime,
              
            }).ToList();

            return new TranslationOfTransactionQueryResponse(transactionItems);
        }
    }
}