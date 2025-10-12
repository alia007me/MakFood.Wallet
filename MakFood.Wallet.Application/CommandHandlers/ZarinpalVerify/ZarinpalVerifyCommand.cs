using MakFood.Wallet.Application.CommandHandlers.Base;
using MakFood.Wallet.Application.CommandHandlers.Base.Extensions;
using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ZarinpalVerify
{
    public class ZarinpalVerifyCommand : CommandBase, IRequest<ZarinpalVerifyCommandResponse>
    {
        public string merchant_id { get; set; } = default!;
        public string authority { get; set; } = default!;
        public string status { get; set; } = default!;
        public override void Validate()
        {
            new ZarinpalVerifyCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
