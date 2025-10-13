using MakFood.Wallet.Application.ServiceContracts;
using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Enums;
using MakFood.Wallet.Domain.Model.Events.WalletEvents;
using MakFood.Wallet.Infrastructure.Context;
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
        private readonly IWalletRepository _walletRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IZarinpalGateway _zarinpalGateway;

        public ZarinpalVerifyCommandHandler( IWalletRepository walletRepository, IUnitOfWork unitOfWork, IZarinpalGateway zarinpalGateway)
        {
            _walletRepository = walletRepository;
            _unitOfWork = unitOfWork;
            _zarinpalGateway = zarinpalGateway;
        }

        public async Task<ZarinpalVerifyCommandResponse> Handle(ZarinpalVerifyCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _walletRepository.GetTransactionAsync(request.authority);
            if (transaction == null)
                throw new Exception("TransactionNotFound");
            var wallet = await _walletRepository.GetWalletById(transaction.WalletId, cancellationToken);
            if (wallet == null) throw new Exception("WalletNotFound");

            if (request.status != "OK")
            {
                transaction.Cancelled();
                var response = new ZarinpalVerifyCommandResponse() { message = "Transaction Cancelled" };
                return response;
            }

            var result = await _zarinpalGateway.VerifyTransactionFromZarinpal(request.authority, transaction.Amount);
            if (result?.data.code == 100)
            {
                wallet.Apply(new BalanceIncreasedOnlineEvent(transaction.Amount, PaymentMethod.Online));
                transaction.UpdateTransactionNumber(result.data.ref_id.ToString());
                transaction.Done();
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

