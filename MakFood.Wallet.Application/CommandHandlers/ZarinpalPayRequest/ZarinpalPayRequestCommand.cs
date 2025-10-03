using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ZarinpalPayRequest
{
    public class ZarinpalPayRequestCommand : IRequest<ZarinpalPayRequestCommandResponse>
    {
        public decimal Amount { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

    }
}
