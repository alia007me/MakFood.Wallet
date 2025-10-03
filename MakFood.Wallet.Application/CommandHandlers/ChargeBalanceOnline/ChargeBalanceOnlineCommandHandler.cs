using MakFood.Wallet.Domain.Model.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOnline
{
    public class ChargeBalanceOnlineCommandHandler : IRequestHandler<ChargeBalanceOnlineCommand, ChargeBalanceOnlineCommandResponse>
    {
        private readonly IChargeRepository _chargeRepository;
        public ChargeBalanceOnlineCommandHandler(IChargeRepository chargeRepository)
        {
            _chargeRepository = chargeRepository;
        }

        public async Task<ChargeBalanceOnlineCommandResponse> Handle(ChargeBalanceOnlineCommand request, CancellationToken cancellationToken)
        {



            request.Write.CancellationToken = cancellationToken;
            var result = await _chargeRepository.ChargeBalanceOnlineAsync(request.Write);
            var response = new ChargeBalanceOnlineCommandResponse()
            {
                Result = result
            };
            if (response.Result == "Invalid")
                return response;
            else
            {
              
                return response;
            }


        }


    }
}
