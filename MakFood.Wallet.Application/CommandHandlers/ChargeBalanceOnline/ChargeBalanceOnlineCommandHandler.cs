using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Infrastructure.Context;
using MakFood.Wallet.Infrastructure.Repositories.ServiceContracts;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IChargeWalletRepository _chargeWallet;
        private readonly IZarinpalGateway _zarinpalGateway;
        private readonly ITransactionRepository _transactionRepository;

        public ChargeBalanceOnlineCommandHandler(IUnitOfWork unitOfWork, IChargeWalletRepository chargeWallet, IZarinpalGateway zarinpalGateway, ITransactionRepository transactionRepository)
        {
            _unitOfWork = unitOfWork;
            _chargeWallet = chargeWallet;
            _zarinpalGateway = zarinpalGateway;
            _transactionRepository = transactionRepository;
        }

        public async Task<ChargeBalanceOnlineCommandResponse> Handle(ChargeBalanceOnlineCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _chargeWallet.GetWalletById(request.Id,cancellationToken);

            var result = await _zarinpalGateway.PayRequest(request.Amount, request.Email, request.Description);
            if(result.data.code == 100) 
            {
                await _transactionRepository.AddTransactionAsync(request.Id, result.data.authority, request.Amount ,Domain.Model.Enums.PaymentMethod.Online,DateTime.Now , Domain.Model.Enums.PaymentStatus.Pending);
                var response = new ChargeBalanceOnlineCommandResponse()
                {
                    Message = $"https://sandbox.zarinpal.com/pg/StartPay/{result.data.authority}"
                };
                return response;
            }
            else
            {
                throw new Exception("Your Request For Charging Your Balance Has Failed !");
            }


        }
    }
}
