using MakFood.Wallet.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline
{
    internal class ChargeBalanceOfflineCommandHandler : IRequestHandler<ChargeBalanceOfflineCommand, bool>
    {
        private readonly IChargeRepository _chargeRepository;

        public ChargeBalanceOfflineCommandHandler(IChargeRepository chargeRepository)
        {
            _chargeRepository = chargeRepository;
        }

        public async Task<bool> Handle(ChargeBalanceOfflineCommand request, CancellationToken cancellationToken)
        {
            var result = await _chargeRepository.ChargeBalanceOfflineAsync(request.id, request.amount);
            if (result)
                return true;
            else return false;
        }
    }
}
