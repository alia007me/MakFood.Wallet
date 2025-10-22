using MakFood.Wallet.Application.ServiceContracts;
using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Enums;
using MakFood.Wallet.Infrastructure.Context;
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

        private readonly IWalletRepository _walletRepository;

        private readonly IZarinpalGateway _zarinpalGateway;


        public ChargeBalanceOnlineCommandHandler(IUnitOfWork unitOfWork, IWalletRepository walletRepository, IZarinpalGateway zarinpalGateway)
        {
            _unitOfWork = unitOfWork;
            _walletRepository = walletRepository;
            _zarinpalGateway = zarinpalGateway;
        }

        public async Task<ChargeBalanceOnlineCommandResponse> Handle(ChargeBalanceOnlineCommand request, CancellationToken cancellationToken)
        {

            var wallet = await _walletRepository.GetWalletById(request.Id,cancellationToken);


            var result = await _zarinpalGateway.PayRequest(request.Amount, request.Email, request.Description);
            if(result.data.code == 100) 
            {
                _walletRepository.AddTransaction(request.Id, result.data.authority, request.Amount ,PaymentMethod.Online,DateTime.Now ,PaymentStatus.Pending);
                await _unitOfWork.AddEventSourcesCommit(cancellationToken);
                var response = new ChargeBalanceOnlineCommandResponse()
                {
                    authority = result.data.authority
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
