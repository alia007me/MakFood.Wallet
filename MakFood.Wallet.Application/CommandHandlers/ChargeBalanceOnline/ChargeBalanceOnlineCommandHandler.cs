using MakFood.Wallet.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOnline
{
    public class ChargeBalanceOnlineCommandHandler : IRequestHandler<ChargeBalanceOnlineCommand, string>
    {
        private readonly IChargeRepository _chargeRepository;

        public ChargeBalanceOnlineCommandHandler(IChargeRepository chargeRepository)
        {
            _chargeRepository = chargeRepository;
        }

        public async Task<string> Handle(ChargeBalanceOnlineCommand request, CancellationToken cancellationToken)
        {
            var result = await _chargeRepository.ChargeBalanceOnlineAsync(request.Write);
            return result;
        }


    }
}
