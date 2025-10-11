using MakFood.Wallet.Application.CommandHandlers.Base;
using MakFood.Wallet.Application.CommandHandlers.Base.Extensions;
using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOnline;
using MakFood.Wallet.Domain.Model.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.PayOrderDetails
{
    public class PayOrderDetailsComand : CommandBase, IRequestHandler<PayOrderDetailsComandResponse>
    {
        public Guid OrderDetailId { get; private set; }
        public Decimal OrderAmount { get; private set; }
        public Guid DiscountCodeID { get; private set; }
        public Guid CustomerID { get; private set; }

        public override void Validate()
        {
            new PayOrderDetailsComandValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
