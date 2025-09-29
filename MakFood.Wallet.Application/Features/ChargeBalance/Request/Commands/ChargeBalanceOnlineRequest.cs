using MakFood.Wallet.Application.DTOs.ChargeBalanceDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.Features.ChargeBalance.Request.Commands
{
    public class ChargeBalanceOnlineRequest : IRequest<string>
    {
        public ChargeBalanceWriteDTO Write { get; set; }

    }
}
