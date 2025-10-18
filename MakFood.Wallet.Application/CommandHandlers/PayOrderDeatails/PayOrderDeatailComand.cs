using Azure;
using FluentValidation;
using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Services;
using MakFood.Wallet.Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.PayOrderDeatails
{
    public class PayOrderDeatailComand: IRequest<PayOrderDeatailComandRespone>
    {
        public Guid WalletID { get; set; }
        public Guid OrdearDeatais { get; set; }

    }
    public class PayOrderDeatailComandHandler : IRequestHandler<PayOrderDeatailComand, PayOrderDeatailComandRespone>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PayOrderDeatailComandHandler(IWalletRepository walletRepository, IUnitOfWork unitOfWork)
        {
            _walletRepository = walletRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PayOrderDeatailComandRespone> Handle(PayOrderDeatailComand request, CancellationToken ct)
        {
            PayOrderDeatailComandRespone respon;
            var wallet = await (_walletRepository.GetWalletById(request.WalletID, ct));
            var order = wallet.OrderDetails.SingleOrDefault(x => x.OrderDetailId == request.OrdearDeatais);
            if (order is null)
                throw new Exception("your order is not defiend");
            else if (order.isPaied == true)
                throw new Exception("this order is paied");
            decimal shortageAmount = wallet.tryToPay(order, ct);
            if (shortageAmount == 0) {
                respon = new PayOrderDeatailComandRespone()
                {

                    response = "your order is paied"
                };
            }
            else {
                respon = new PayOrderDeatailComandRespone()
                {

                    response = $"you don't have enough money pay this and try again "
                };
            }

            return respon;

        }
    }
    public class PayOrderDeatailComandRespone
    {
        public string response{ get; set; }
    }
    public class PayOrderDeatailComandvalidator : AbstractValidator<PayOrderDeatailComand>
    {

    }
}
