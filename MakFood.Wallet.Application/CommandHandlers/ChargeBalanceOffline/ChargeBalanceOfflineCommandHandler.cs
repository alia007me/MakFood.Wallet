using Azure.Core;
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
            //var wallet = await _chargeWalletRepository.GetWalletById(request.Walletid ,cancellationToken);
            var wallet = await GetWallet(request.Walletid,cancellationToken);
            
            wallet.Apply(new BalanceIncreasedOfflineWaitingForApproveEvent(request.Amount));
            //await _chargeWalletRepository.AddTransaction(request.Walletid,transactionNumber, request.Amount,
            //    PaymentMethod.Offline, DateTime.Now, PaymentStatus.Pending);
            AddOneTransaction(request.Walletid,transactionNumber,request.Amount);


            var response = new ChargeBalanceOfflineCommandResponse()
            {
                TransactionNumber = transactionNumber
            };

            return response;
        }


        #region Private Methods
        private async Task<Wallet.Domain.Model.Entities.Wallet> GetWallet(Guid walletid, CancellationToken ct)
        {
            var wallet = await _chargeWalletRepository.GetWalletById(walletid, ct);
            if (wallet == null) { throw new Exception("WalletNotFound"); }
            return wallet;
        }

        private void AddOneTransaction(Guid walletid,string transactionNumber,decimal amount)
        {
             _chargeWalletRepository.AddTransaction(walletid, transactionNumber, amount,
                                        PaymentMethod.Offline, DateTime.Now, PaymentStatus.Pending);
        }
        #endregion
    }
}
