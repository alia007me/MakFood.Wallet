using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOnline
{
    public class ChargeBalanceOnlineCommand : IRequest<ChargeBalanceOnlineCommandResponse>
    {
        public Guid Id { get; set; }
        public Decimal Amount { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
