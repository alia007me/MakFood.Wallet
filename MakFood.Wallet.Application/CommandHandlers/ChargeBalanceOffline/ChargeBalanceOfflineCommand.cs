using MakFood.Wallet.Application.CommandHandlers.Base;
using MakFood.Wallet.Application.CommandHandlers.Base.Extensions;
using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOnline;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline
{
    public class ChargeBalanceOfflineCommand : CommandBase,IRequest<ChargeBalanceOfflineCommandResponse>
    {
        public Guid Walletid { get; set; }
        public Decimal Amount { get; set; }
        public override void Validate()
        {
            new ChargeBalanceOfflineCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
