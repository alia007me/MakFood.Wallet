using MakFood.Wallet.Application.CommandHandlers.Base;
using MakFood.Wallet.Application.CommandHandlers.Base.Extensions;
using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline;
using MediatR;

namespace MakFood.Wallet.Application.CommandHandlers.AddOrderDeatails
{
    public class AddOrderDetailCommand : CommandBase, IRequest<AddOrderDetailCommandResponse>
    {
        public decimal OrderAmount { get; set; }
        public Guid? DicontcodeID { get; set; }
        public Guid WalletID { get; set; }
        public override void Validate()
        {
            new AddOrderDetailCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
