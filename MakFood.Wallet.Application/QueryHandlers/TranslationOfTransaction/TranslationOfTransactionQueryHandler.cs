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
        private readonly IWalletRepository _walletRepository;

        public TranslationOfTransactionQueryHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<TranslationOfTransactionQueryResponse> Handle(
            TranslationOfTransactionQuery request,
            CancellationToken cancellationToken)
        {

            var transactions = await _walletRepository.GetTransaction(request.WalletId, request.dateTime);

            var transactionItems = transactions.Select(c => new TranslationOfTransactionQueryResponse.TransactionItem
            {
                Amount = c.Amount,
                WalletId = c.WalletId,
                dateTime = c.DateTime,
                TransactionNumber = c.TransactionNumber
            }).ToList();
            ///
            return new TranslationOfTransactionQueryResponse(transactionItems);
        }
    }
}