using MakFood.Wallet.Application.CommandHandlers.AddOrderDeatails;
using MakFood.Wallet.Application.CommandHandlers.AddWalet;
using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline;
using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOnline;
using MakFood.Wallet.Application.CommandHandlers.ChefApprove;
using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakFood.Wallet.Host.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public WalletController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }
        [HttpPost("Wallet/{custumerId}")]
        public async Task<IActionResult> AddWallet([FromBody] AddWalletCommand addWalletCommand)
        {
            addWalletCommand.Validate();
            var result = await _mediator.Send(addWalletCommand);
            return Ok("you Wallet created");
        }

        [HttpPatch("Wallet/{walletId}/Balance/Increase/Online")]
        public async Task<IActionResult> ChargeWallet([FromBody] ChargeBalanceOnlineCommand chargeBalanceOnline)
        {
            chargeBalanceOnline.Validate();


            var result = await _mediator.Send(chargeBalanceOnline);
            return Ok($"https://sandbox.zarinpal.com/pg/StartPay/{result.authority}");

        }
        [HttpPost("Wallet/{walletId}/Balance/Increase/Offline")]
        public async Task<IActionResult> ChargeOfflineWallet([FromBody] ChargeBalanceOfflineCommand chargeBalanceOffline, CancellationToken ct)
        {
            chargeBalanceOffline.Validate();
            var result = await _mediator.Send(chargeBalanceOffline);

            await _unitOfWork.AddEventSourcesCommit(ct);

            return Ok($"Your Request Submitted . YourTransactionNumber {result.TransactionNumber}");
        }

        [HttpPost("Wallet/{WalletId}/OrderDeatail/{OrderDeatail}")]
        public async Task<IActionResult> AddOrderDeatail([FromBody] AddOrderDetailCommand AddOrderDetail, CancellationToken ct)
        {
            AddOrderDetail.Validate();
            var result = await _mediator.Send(AddOrderDetail);
            await _unitOfWork.Commit(ct);
            return Ok(result.Respone);
        }


        [HttpPatch("Wallet/{walletId}/Balance/Increase/Approve")]
        public async Task<IActionResult> ChefApprove([FromBody] ApproveCommand chefApprove, CancellationToken ct)
        {

            var result = await _mediator.Send(chefApprove);

            await _unitOfWork.AddEventSourcesCommit(ct);

            return Ok($"Wallet {result.WalletId} Charged Successfully ! ");

        }

    }
}
