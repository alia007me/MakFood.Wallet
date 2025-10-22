using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Entities;
using MakFood.Wallet.Domain.Model.Services;
using MakFood.Wallet.Infrastructure.Context;
using MediatR;


namespace MakFood.Wallet.Application.CommandHandlers.AddOrderDeatails
{
    public class AddOrderDetailCommandHandler : IRequestHandler<AddOrderDetailCommand
        ,AddOrderDetailCommandResponse> 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWalletRepository _walletRepository;
        public AddOrderDetailCommandHandler(IUnitOfWork unitOfWork, IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddOrderDetailCommandResponse> Handle(AddOrderDetailCommand request, CancellationToken ct)
        {
            var wallet = await _walletRepository.GetWalletById(request.WalletID,ct);
            var order = new OrderDetails(request.OrderAmount);
            wallet.OrderDetails.Add(order);
            _unitOfWork.DetectAdded(order);
            await _unitOfWork.Commit(ct);
            var respone = new AddOrderDetailCommandResponse()
            {
                Respone=$"Your amount was '{request.OrderAmount}' , your order ID {order.OrderDetailId}"
            };
            return respone;
        }

    }
}
