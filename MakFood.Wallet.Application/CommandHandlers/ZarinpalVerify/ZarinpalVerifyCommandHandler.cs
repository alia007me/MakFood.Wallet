using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Events.WalletEvents;
using MakFood.Wallet.Infrastructure.Context;
using MakFood.Wallet.Infrastructure.Repositories.ServiceContracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ZarinpalVerify
{
    public class ZarinpalVerifyCommandHandler : IRequestHandler<ZarinpalVerifyCommand, ZarinpalVerifyCommandResponse>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IChargeWalletRepository _chargeWalletRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IZarinpalGateway _zarinpalGateway;

        public ZarinpalVerifyCommandHandler(ITransactionRepository transactionRepository, IChargeWalletRepository chargeWalletRepository, IUnitOfWork unitOfWork, IZarinpalGateway zarinpalGateway)
        {
            _transactionRepository = transactionRepository;
            _chargeWalletRepository = chargeWalletRepository;
            _unitOfWork = unitOfWork;
            _zarinpalGateway = zarinpalGateway;
        }

        public async Task<ZarinpalVerifyCommandResponse> Handle(ZarinpalVerifyCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetTransactionAsync(request.authority);
            if (transaction == null)
                throw new Exception("TransactionNotFound");
            var wallet = await _chargeWalletRepository.GetWalletById(transaction.WalletId, cancellationToken);
            if (wallet == null) throw new Exception("WalletNotFound");

            if (request.status != "OK")
            {
                transaction.UpdateTransactionStatusToCancelled();
                var response = new ZarinpalVerifyCommandResponse() { message = "Transaction Cancelled" };
                return response;
            }

            var result = await _zarinpalGateway.VerifyTransactionFromZarinpal(request.authority, transaction.Amount);
            if (result?.data.code == 100)
            {
                wallet.Apply(new MoneyIncreasedEvent(transaction.Amount, Domain.Model.Enums.PaymentMethod.Online));
                transaction.UpdateTransactionNumber(result.data.ref_id.ToString());
                transaction.UpdateTransacationStatusToDone();
                var response = new ZarinpalVerifyCommandResponse()
                {
                    message = $"Transaction Completed SuccessFully .  TransactionNumber : {result.data.ref_id}"
                };
                return response;

            }
            else
            {
                var response = new ZarinpalVerifyCommandResponse()
                {
                    message = $"Your Transaction Didn't Verify ! TransactionCode : {result.data.ref_id}"
                };
                return response;
            }
        }
    }
}

