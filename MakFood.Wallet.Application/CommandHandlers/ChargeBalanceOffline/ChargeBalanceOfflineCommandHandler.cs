using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOnline;
using MakFood.Wallet.Domain.Model.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline
{
    public class ChargeBalanceOfflineCommandHandler : IRequestHandler<ChargeBalanceOfflineCommand, ChargeBalanceOfflineCommandResponse>
    {
        private readonly IChargeRepository _chargerepository;

        public ChargeBalanceOfflineCommandHandler(IChargeRepository chargerepository)
        {
            _chargerepository = chargerepository;
        }

        public async Task<ChargeBalanceOfflineCommandResponse> Handle(ChargeBalanceOfflineCommand request, CancellationToken cancellationToken)
        {
            var result = await _chargerepository.ChargeBalanceOffline(request.request);
            var response = new ChargeBalanceOfflineCommandResponse();
            if (result)
            {
                response.Response = "Please Wait Until Chef Accept Your Payment";
                return response;
            }
            else
            {
                response.Response = "Please Pay Your Money Then Send Request !";
                return response;
            }
        }
    }
}
