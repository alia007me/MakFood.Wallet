using MakFood.Wallet.Domain.Model.Contracts;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.QueryHandlers.Transaction
{
    public class ShowTransactionQueryHandler
        : IRequestHandler<ShowTransactionQuery, ShowTransactionQueryResponse>
    {
        private readonly IWalletRepository _walletRepository;

        public ShowTransactionQueryHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<ShowTransactionQueryResponse> Handle(
            ShowTransactionQuery request,
            CancellationToken cancellationToken)
        {

            var transactions = await _walletRepository.GetTransaction(request.WalletId, request.dateTime);

            var transactionItems = transactions.Select(c => new ShowTransactionQueryResponse.TransactionItem
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