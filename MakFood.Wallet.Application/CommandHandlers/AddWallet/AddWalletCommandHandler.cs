using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Infrastructure.Context;
using MediatR;

namespace MakFood.Wallet.Application.CommandHandlers.AddWalet
{
    public class AddWalletCommandHandler : IRequestHandler<AddWalletCommand, AddWalletCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWalletRepository _walletRepository;

        public AddWalletCommandHandler(IUnitOfWork unitOfWork, IWalletRepository walletRepository) { 
            _unitOfWork = unitOfWork;
            _walletRepository = walletRepository;
        }
        public async Task<AddWalletCommandResponse> Handle(AddWalletCommand request, CancellationToken ct)
        {
            await _walletRepository.AddWallet(request.CustumerID);
            await _unitOfWork.Commit(ct);
            return new AddWalletCommandResponse();
        }


    }
}
