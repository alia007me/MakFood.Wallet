using MakFood.Wallet.Application.CommandHandlers.Base;
using MakFood.Wallet.Application.CommandHandlers.Base.Extensions;
using MediatR;


namespace MakFood.Wallet.Application.CommandHandlers.AddWalet
{
    public class AddWalletCommand : CommandBase, IRequest<AddWalletCommandResponse>
    {
        public Guid CustumerID { get; set; }
        public override void Validate()
        {
            new AddWalletCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
