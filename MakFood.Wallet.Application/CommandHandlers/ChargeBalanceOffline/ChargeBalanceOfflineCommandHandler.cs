using MakFood.Wallet.Application.CommandHandlers.RobertInaroAzAvalBiar;
using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Enums;
using MakFood.Wallet.Domain.Model.Events.WalletEvents;
using MakFood.Wallet.Domain.Model.Services.Contract;
using MakFood.Wallet.Infrastructure.Context;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline
{
    public class ChargeBalanceOfflineCommandHandler : IRequestHandler<ChargeBalanceOfflineCommand, ChargeBalanceOfflineCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWalletRepository _chargeWalletRepository;
        private readonly IOfflineTransactionNumberGenerator _transactionNumberGenerator;

        public ChargeBalanceOfflineCommandHandler(IUnitOfWork unitOfWork,
            IWalletRepository chargeWalletRepository, IOfflineTransactionNumberGenerator transactionNumberGenerator)
        {
            _unitOfWork = unitOfWork;
            _chargeWalletRepository = chargeWalletRepository;
            _transactionNumberGenerator = transactionNumberGenerator;
        }

        public async Task<ChargeBalanceOfflineCommandResponse> Handle(ChargeBalanceOfflineCommand request, CancellationToken cancellationToken)
        {
            var transactionNumber = _transactionNumberGenerator.GenerateTransactionNumber();
            var wallet = await _chargeWalletRepository.GetWalletById(request.Walletid ,cancellationToken);
            
            wallet.Apply(new BalanceIncreasedOfflineWaitingForApproveEvent(request.Amount));
            await _chargeWalletRepository.AddTransactionAsync(request.Walletid,transactionNumber, request.Amount,
                PaymentMethod.Offline, DateTime.Now, PaymentStatus.Pending);


            var response = new ChargeBalanceOfflineCommandResponse()
            {
                Message = $"Your Request Submitted . YourTransactionNumber : {transactionNumber}"
            };

            return response;
        }
    }
}
