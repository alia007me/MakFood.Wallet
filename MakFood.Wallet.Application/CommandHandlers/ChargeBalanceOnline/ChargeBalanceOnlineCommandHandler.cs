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
            var validator = new ChargeBalanceOnlineCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new Exception(errors);
            }


            request.Write.CancellationToken = cancellationToken;
            var result = await _chargeRepository.ChargeBalanceOnlineAsync(request.Write);
            var response = new ChargeBalanceOnlineCommandResponse()
            {
                Result = result
            };
            
            return response;
        }


    }
}
