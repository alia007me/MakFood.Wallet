using MakFood.Wallet.Application.CommandHandlers.Base;
using MediatR;

namespace MakFood.Wallet.Application.QueryHandlers.Transaction
{
    public class TranslationOfTransactionQuery : QueryBase, IRequest<TranslationOfTransactionQueryResponse>
    {
        public Guid WalletId { get; set; }
        public DateTime dateTime { get; set; }
        public override void Validate()
        {
            throw new NotImplementedException();
        }
        
       
    }
}