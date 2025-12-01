using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOnline;
using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Entities;
using MakFood.Wallet.Domain.Model.Services;
using MakFood.Wallet.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MakFood.Wallet.Application.CommandHandlers.PayOrderDeatails
{
    public class PayOrderDeatailComandHandler : IRequestHandler<PayOrderDeatailComand, PayOrderDeatailComandRespone>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public PayOrderDeatailComandHandler(IWalletRepository walletRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _walletRepository = walletRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<PayOrderDeatailComandRespone> Handle(PayOrderDeatailComand request, CancellationToken ct)
        {
            PayOrderDeatailComandRespone respon;
            var wallet = await (_walletRepository.GetWalletById(request.WalletID, ct));
            var order = wallet.OrderDetails.SingleOrDefault(x => x.OrderDetailId == request.OrdearDeataisID);
            OrderValidation(order);
            decimal shortageAmount = wallet.tryToPay(order, ct);
            if (shortageAmount == 0) {
                respon = new PayOrderDeatailComandRespone()
                {

                    response = "your order is paied"
                };
            }
            else {
                var result =await SendForPayOnline(wallet, shortageAmount);
                respon = new PayOrderDeatailComandRespone
                {
                    response = $"your wallet amount is not enough pay this  : https://sandbox.zarinpal.com/pg/StartPay/{result.authority}"
                };
            }
            await _unitOfWork.AddEventSourcesCommit(ct);
            return respon;

        }
        #region
        private void OrderValidation(OrderDetails order) {
            if (order is null)
                throw new Exception("your order is not defiend");
            else if (order.isPaied == true)
                throw new Exception("this order is paied");
        }
        #endregion
        #region
        private async Task<ChargeBalanceOnlineCommandResponse> SendForPayOnline (Domain.Model.Entities.Wallet Wallet,decimal shortageAmount) {
        
            var caharge = new ChargeBalanceOnlineCommand
            {
                Id = Wallet.WalletId,
                Amount = shortageAmount,
                Email = "test@gmail.com",
                Description = "Order payment shortage"
            };

            caharge.Validate();

            return await _mediator.Send(caharge);
            #endregion
        }

    }
}