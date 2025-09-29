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
    internal class ChargeBalanceOfflineRequestHandler : IRequestHandler<ChargeBalanceOfflineRequest, bool>
    {
        private readonly IChargeRepository _chargeRepository;

        public ChargeBalanceOfflineRequestHandler(IChargeRepository chargeRepository)
        {
            _chargeRepository = chargeRepository;
        }

        public async Task<bool> Handle(ChargeBalanceOfflineRequest request, CancellationToken cancellationToken)
        {
            var result = await _chargeRepository.ChargeBalanceOfflineAsync(request.id, request.amount);
            if (result)
                return true;
            else return false;
        }
    }
}
