using MakFood.Wallet.Application.Contracts;
using MakFood.Wallet.Application.Features.ChargeBalance.Request.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.Features.ChargeBalance.Handler.Commands
{
    public class ChargeBalanceOnlineRequestHandler : IRequestHandler<ChargeBalanceOnlineRequest, string>
    {
        private readonly IChargeRepository _chargeRepository;

        public ChargeBalanceOnlineRequestHandler(IChargeRepository chargeRepository)
        {
            _chargeRepository = chargeRepository;
        }

        public async Task<string> Handle(ChargeBalanceOnlineRequest request, CancellationToken cancellationToken)
        {
            var result = await _chargeRepository.ChargeBalanceOnlineAsync(request.Write);
            return result;
        }


    }
}
