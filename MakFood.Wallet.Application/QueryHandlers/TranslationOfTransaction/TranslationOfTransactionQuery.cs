using MakFood.Wallet.Application.CommandHandlers.Base;
using MakFood.Wallet.Application.CommandHandlers.Base.Extensions;
using MediatR;

namespace MakFood.Wallet.Application.QueryHandlers.Transaction
{
    public class TranslationOfTransactionQuery : QueryBase, IRequest<TranslationOfTransactionQueryResponse>
    {
        public Guid WalletId { get; set; }
        public DateTime dateTime { get; set; }

        public override void Validate()
        {
            new TranslationOfTransactionQueryValidator().Validate(this).ThrowIfNeeded();
        }
    }
}