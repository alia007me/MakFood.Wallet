using System.IO.Pipelines;

namespace MakFood.Wallet.Application.QueryHandlers.Transaction
{

    public class TranslationOfTransactionQueryResponse
    {
        public List<TransactionItem> transactionItems { get; set; }
        public TranslationOfTransactionQueryResponse(List<TransactionItem> transactionItems)
        {
            this.transactionItems = transactionItems;
        }
        public class TransactionItem

        {
            public Guid Id { get; set; }
            public Guid WalletId { get; set; }
            public DateTime dateTime { get; set; }
            public Decimal Amount { get; set; }
            public string TransactionNumber { get; set; }
        }




    }

}