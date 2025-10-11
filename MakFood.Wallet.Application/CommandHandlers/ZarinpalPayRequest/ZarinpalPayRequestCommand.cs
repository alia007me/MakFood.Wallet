using MakFood.Wallet.Application.CommandHandlers.Base;
using MakFood.Wallet.Application.CommandHandlers.Base.Extensions;
using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ZarinpalPayRequest
{
    public class ZarinpalPayRequestCommand : CommandBase ,  IRequest<ZarinpalPayRequestCommandResponse>
    {
        public decimal Amount { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public override void Validate()
        {
            new ZarinpalPayRequestCommandValidator().Validate(this).ThrowIfNeeded();
        }

    }
}
