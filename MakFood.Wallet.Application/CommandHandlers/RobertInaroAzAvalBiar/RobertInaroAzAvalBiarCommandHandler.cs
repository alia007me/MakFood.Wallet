using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Services;
using MakFood.Wallet.Infrastructure.Context;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.RobertInaroAzAvalBiar
{
    public class RobertInaroAzAvalBiarCommandHandler : IRequestHandler<RobertInaroAzAvalBiarCommand, RobertInaroAzAvalBiarCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWalletRepository _walletRepository;
        private readonly IReplyEventRepository _replyEventRepository;


        public RobertInaroAzAvalBiarCommandHandler(IWalletRepository walletRepository, IReplyEventRepository replyEventRepository, IUnitOfWork unitOfWork )
        {
            _walletRepository = walletRepository;
            _replyEventRepository = replyEventRepository;
            _unitOfWork = unitOfWork;            
        }

        public async Task<RobertInaroAzAvalBiarCommandResponse> Handle(RobertInaroAzAvalBiarCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetWalletById(request.Id, cancellationToken);
            if (wallet == null) { throw new Exception("Hessab Nadari robert"); }
            var events = await _replyEventRepository.GetWaletEvent(request.Id, DateTime.Now, cancellationToken);
           
            wallet.Replay(EventFactoryExtantion.GenerateEvent(events));
            await _unitOfWork.Commit(cancellationToken);
 

            var response = new RobertInaroAzAvalBiarCommandResponse()
            {
                message = $"Your Balance is {wallet.Balance}"
            };
            return response;

        }
    }
}
