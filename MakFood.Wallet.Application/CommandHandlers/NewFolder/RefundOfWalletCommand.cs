using Application.Commands.WithdrawWallet;
using MakFood.Wallet.Application.CommandHandlers.Base;
using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakFood.Wallet.Application.CommandHandlers.Base.Extensions;

namespace MakFood.Wallet.Application.CommandHandlers.RefundOfWallet
{
    public class RefundOfWalletCommand : CommandBase, IRequest<RefundOfWalletCommandResponse>
    {
        public Guid WalletId { get; set; }
        public decimal Amount { get; set; }
        public override void Validate()
        {
            new RefundOfWalletCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }

}