using MakFood.Wallet.Application.ServiceContracts;
using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Infrastructure.Context;
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
        private readonly IWalletRepository _chargeRep;
        private readonly IZarinpalGateway _zarinpalGateway;
        private readonly IUnitOfWork _unitOfWork;
        public ZarinpalPayRequestCommandHandler(IWalletRepository chargeRep, IZarinpalGateway zarinpalGateway, IUnitOfWork unitOfWork)
        {
            _chargeRep = chargeRep;
            _zarinpalGateway = zarinpalGateway;
            _unitOfWork = unitOfWork;
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
                    PayPath = authority
                };
                return link;

            }
        }
    }
}
