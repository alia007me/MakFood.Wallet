using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ChefApprove
{
    public class ChefApproveCommand : IRequest<ChefApproveCommandResponse>
    {
        public Guid Walletid { get; set; }
        public Decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        [JsonIgnore]
        public CancellationToken cancellationToken { get; set; }
    }
}
