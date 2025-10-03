using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Entities;
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
        private readonly IChargeRepository _chargeRepository;

        public ChefApproveCommandHandler(IChargeRepository chargeRepository)
        {
            _chargeRepository = chargeRepository;
        }

        public async Task<ChefApproveCommandResponse> Handle(ChefApproveCommand request, CancellationToken cancellationToken)
        {
            var result = await _chargeRepository.CheckChefResponseAsync(new Domain.Model.Dtos.ChefResponseDto()
            {
                Amount = request.Amount,
                DateTime = request.DateTime,
                Walletid = request.Walletid,
            });
            var ApproveResponse = new ChefApproveCommandResponse() { Message = result};

            if (result.Contains("Your Wallet Charged SuccessFully"))
            {
                return ApproveResponse;
            }
            else
                return ApproveResponse;

        }
    }
}
