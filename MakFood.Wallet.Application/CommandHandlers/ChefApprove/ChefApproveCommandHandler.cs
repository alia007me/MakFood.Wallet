using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Enums;
using MakFood.Wallet.Domain.Model.Services.Contract;
using MakFood.Wallet.Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ChefApprove
{
    public class ChefApproveCommandHandler : IRequestHandler<ChefApproveCommand, ChefApproveCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IOfflineTransactionNumberGenerator _transactionNumberGenerator;
        private readonly IChargeWalletRepository _chargeWalletRepository;

        public ChefApproveCommandHandler(IUnitOfWork unitOfWork, ITransactionRepository transactionRepository,
            IOfflineTransactionNumberGenerator transactionNumberGenerator, IChargeWalletRepository chargeWalletRepository)
        {
            _unitOfWork = unitOfWork;
            _transactionRepository = transactionRepository;
            _transactionNumberGenerator = transactionNumberGenerator;
            _chargeWalletRepository = chargeWalletRepository;
        }

        public async Task<ChefApproveCommandResponse> Handle(ChefApproveCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetTransactionAsync(request.TransactionNumber);
            if (transaction == null || transaction.Status == PaymentStatus.Done) { throw new Exception("TransactionNotFoundOrDone"); };
            var wallet = await _chargeWalletRepository.GetWalletById(transaction.WalletId, cancellationToken);
            if (wallet == null) { throw new Exception("WalletNotFound"); }

            wallet.Apply(new Domain.Model.Events.WalletEvents.MoneyIncreasedEvent(transaction.Amount,PaymentMethod.Offline));
            transaction.UpdateTransacationStatusToDone();
            await _unitOfWork.Commit(cancellationToken);

            var response = new ChefApproveCommandResponse()
            {
                Message = $" Wallet {wallet.WalletId} Charged Successfully"
            };
            return response;

        }
    }
}
