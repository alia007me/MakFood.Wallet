using Azure.Core;
using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Entities;
using MakFood.Wallet.Domain.Model.Enums;
using MakFood.Wallet.Domain.Model.Events.WalletEvents;
using MakFood.Wallet.Domain.Model.Services.Contract;
using MakFood.Wallet.Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ChefApprove
{
    public class ApproveCommandHandler : IRequestHandler<ApproveCommand, ApproveCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOfflineTransactionNumberGenerator _transactionNumberGenerator;
        private readonly IWalletRepository _chargeWalletRepository;

        public ApproveCommandHandler(IUnitOfWork unitOfWork,
            IOfflineTransactionNumberGenerator transactionNumberGenerator, IWalletRepository chargeWalletRepository)
        {
            _unitOfWork = unitOfWork;
            _transactionNumberGenerator = transactionNumberGenerator;
            _chargeWalletRepository = chargeWalletRepository;
        }

        public async Task<ApproveCommandResponse> Handle(ApproveCommand request, CancellationToken cancellationToken)
        {
            //var transaction = await _chargeWalletRepository.GetTransactionAsync(request.TransactionNumber);
            //if (transaction == null || transaction.Status == PaymentStatus.Done) { throw new Exception("TransactionNotFoundOrDone"); }
            //;
            //var wallet = await _chargeWalletRepository.GetWalletById(transaction.WalletId, cancellationToken);
            //if (wallet == null) { throw new Exception("WalletNotFound"); }
            var transaction =await GetTransaction(request.TransactionNumber);
            var wallet = await GetWallet(request.Walletid,cancellationToken);
            //wallet.Apply(new Domain.Model.Events.WalletEvents.BalanceIncreasedOnlineEvent(transaction.Amount,PaymentMethod.Offline));
            //var approver = new OfflineTransactionApprover();
            //switch (request.Approver)
            //{
            //    case "Shirkhodae":
            //        {
            //            approver = OfflineTransactionApprover.Shirkhodae; break;
            //        }
            //    case "Sadeghikia":
            //        {
            //            approver = OfflineTransactionApprover.Sadeghikia; break;
            //        }
            //    case "Taee":
            //        {
            //            approver = OfflineTransactionApprover.Taee; break;
            //        }
            //    case "Dehghan":
            //        {
            //            approver = OfflineTransactionApprover.Dehghan; break;
            //        }
            //    case "Khale":
            //        {
            //            approver = OfflineTransactionApprover.Khale; break;
            //        }
            //}
            var approver = CheckApprover(request.Approver);

            wallet.Apply(new BalanceIncreasedOfflineEvent(transaction.Amount,approver));
            transaction.UpdateTransacationStatusToDone();

            var response = new ApproveCommandResponse()
            {               
                WalletId = wallet.WalletId,
            };
            return response;

        }

        #region Private Methods
        private async Task<Transaction> GetTransaction(string transactionNumber)
        {
            var transaction = await _chargeWalletRepository.GetTransactionAsync(transactionNumber);
            if (transaction == null || transaction.Status == PaymentStatus.Done) { throw new Exception("TransactionNotFoundOrDone"); }
            return transaction;
        }

        private async Task<Wallet.Domain.Model.Entities.Wallet> GetWallet(Guid walletid,CancellationToken ct)
        {
            var wallet = await _chargeWalletRepository.GetWalletById(walletid, ct);
            if (wallet == null) { throw new Exception("WalletNotFound"); }
            return wallet;
        }

        private OfflineTransactionApprover CheckApprover(string input)
        {
            var approver = new OfflineTransactionApprover();
            switch (input)
            {
                case "Shirkhodae":
                    {
                        approver = OfflineTransactionApprover.Shirkhodae; break;
                    }
                case "Sadeghikia":
                    {
                        approver = OfflineTransactionApprover.Sadeghikia; break;
                    }
                case "Taee":
                    {
                        approver = OfflineTransactionApprover.Taee; break;
                    }
                case "Dehghan":
                    {
                        approver = OfflineTransactionApprover.Dehghan; break;
                    }
                case "Khale":
                    {
                        approver = OfflineTransactionApprover.Khale; break;
                    }
                default:
                    { throw new Exception("You Don't Have Premission To Approve"); }
            }
            return approver;
        }

        #endregion
    }
}
