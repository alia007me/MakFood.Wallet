using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ZarinpalVerify
{
    public class ZarinpalVerifyCommand : IRequest<ZarinpalVerifyCommandResponse>
    {
        public string merchant_id { get; set; } = default!;
        public string authority { get; set; } = default!;
    }
}
