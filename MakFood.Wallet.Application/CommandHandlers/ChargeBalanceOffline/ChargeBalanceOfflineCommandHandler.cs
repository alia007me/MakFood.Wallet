using MakFood.Wallet.Application.CommandHandlers.RobertInaroAzAvalBiar;
using MakFood.Wallet.Domain.Model.Contracts;
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
        private readonly ITransactionRepository _transactionRepository;
        private readonly IChargeWalletRepository _chargeWalletRepository;
        private readonly IOfflineTransactionNumberGenerator _transactionNumberGenerator;

        public ChargeBalanceOfflineCommandHandler(IUnitOfWork unitOfWork, ITransactionRepository transactionRepository,
            IChargeWalletRepository chargeWalletRepository, IOfflineTransactionNumberGenerator transactionNumberGenerator)
        {
            _unitOfWork = unitOfWork;
            _transactionRepository = transactionRepository;
            _chargeWalletRepository = chargeWalletRepository;
            _transactionNumberGenerator = transactionNumberGenerator;
        }

        public async Task<ChargeBalanceOfflineCommandResponse> Handle(ChargeBalanceOfflineCommand request, CancellationToken cancellationToken)
        {
            var transactionNumber = _transactionNumberGenerator.GenerateTransactionNumber();
            await _transactionRepository.AddTransactionAsync(request.Walletid,transactionNumber, request.Amount,
                Domain.Model.Enums.PaymentMethod.Offline, DateTime.Now, Domain.Model.Enums.PaymentStatus.Pending);

            var response = new ChargeBalanceOfflineCommandResponse()
            {
                Message = $"Your Request Submitted . YourTransactionNumber : {transactionNumber}"
            };

            return response;
        }
    }
}
