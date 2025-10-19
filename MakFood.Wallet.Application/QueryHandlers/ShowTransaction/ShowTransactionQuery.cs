using MakFood.Wallet.Application.CommandHandlers.Base;
using MakFood.Wallet.Application.CommandHandlers.Base.Extensions;
using MediatR;

namespace MakFood.Wallet.Application.QueryHandlers.Transaction
{
    public class ShowTransactionQuery : QueryBase, IRequest<ShowTransactionQueryResponse>
    {
        public Guid WalletId { get; set; }
        public DateTime dateTime { get; set; }

        public override void Validate()
        {
            new ShowTransactionQueryValidator().Validate(this).ThrowIfNeeded();
        }
    }
}