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
        
        private readonly IDicoountCodeRepository _dicoountCodeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWalletRepository _walletRepository;
        public AddOrderDetailCommandHandler(IDicoountCodeRepository dicoountCodeRepository 
            , IUnitOfWork unitOfWork, IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
            _dicoountCodeRepository = dicoountCodeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddOrderDetailCommandResponse> Handle(AddOrderDetailCommand request, CancellationToken ct)
        {
            var discountCode = await _dicoountCodeRepository.GetDiscountCodeByID(request.DicontcodeID);
            var wallet = await _walletRepository.GetWalletById(request.WalletID,ct);
            Decimal finallAmount= request.OrderAmount;
            if (discountCode is null) {

                wallet.OrderDetails.Add(new OrderDetails(request.OrderAmount));
            }
            else {
                finallAmount = request.OrderAmount.ApplyDicount(discountCode, request.WalletID);
                wallet.OrderDetails.Add(new OrderDetails(request.OrderAmount,request.WalletID,finallAmount));
                
            }
            
            await _unitOfWork.Commit(ct);
            var respone = new AddOrderDetailCommandResponse()
            {
                Respone=$"Your finall amount is {finallAmount}"
            };
            return respone;
        }

    }
}
