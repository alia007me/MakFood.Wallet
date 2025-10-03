using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Infrastructure.Context;
using MakFood.Wallet.Infrastructure.Repositories.ServiceContracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ZarinpalPayRequest
{
    public class ZarinpalPayRequestCommandHandler : IRequestHandler<ZarinpalPayRequestCommand, ZarinpalPayRequestCommandResponse>
    {
        private readonly IChargeWalletRepository _chargeRep;
        private readonly IZarinpalGateway _zarinpalGateway;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionRepository _transactionRepository;
        public ZarinpalPayRequestCommandHandler(IChargeWalletRepository chargeRep, IZarinpalGateway zarinpalGateway, IUnitOfWork unitOfWork, ITransactionRepository transactionRepository)
        {
            _chargeRep = chargeRep;
            _zarinpalGateway = zarinpalGateway;
            _unitOfWork = unitOfWork;
            _transactionRepository = transactionRepository;
        }

        public async Task<ZarinpalPayRequestCommandResponse> Handle(ZarinpalPayRequestCommand request, CancellationToken cancellationToken)
        {
            var result = await _zarinpalGateway.PayRequest(request.Amount, request.Email, request.Description);
            if (result == null || result.data.code != 100)
            {
                throw new Exception("Pay Request Failed");
            }
            else
            {

                var authority = result.data.authority;
                
                var link = new ZarinpalPayRequestCommandResponse()
                {
                    PayPath = $"https://sandbox.zarinpal.com/pg/StartPay/{authority}"
                };
                return link;

            }
        }
    }
}
