using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.Features.ChargeBalance.Request.Commands
{
    public class ChargeBalanceOfflineRequest : IRequest<bool>
    {
        public Guid id { get; set; }
        public Decimal amount { get; set; }

    }
}
