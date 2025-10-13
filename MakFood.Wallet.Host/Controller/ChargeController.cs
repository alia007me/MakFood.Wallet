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
    public class ChargeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWalletRepository _chargeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChargeController(IMediator mediator, IWalletRepository chargeRepository, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _chargeRepository = chargeRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPatch("Wallet/{walletId}/Balance/Increase/Online")]
        public async Task<IActionResult> ChargeWallet([FromBody]ChargeBalanceOnlineCommand chargeBalanceOnline)
        {
            chargeBalanceOnline.Validate();


            var result = await _mediator.Send(chargeBalanceOnline);
            return Ok($"https://sandbox.zarinpal.com/pg/StartPay/{result.authority}");

        }
        [HttpPost("Wallet/{walletId}/Balance/Increase/Offline")]
        public async Task<IActionResult> ChargeOfflineWallet([FromBody] ChargeBalanceOfflineCommand chargeBalanceOffline , CancellationToken ct)
        {
            chargeBalanceOffline.Validate();
            var result = await _mediator.Send(chargeBalanceOffline);

            await _unitOfWork.AddEventSourcesCommit(ct);

            return Ok($"Your Request Submitted . YourTransactionNumber {result.TransactionNumber}");
        }
        [HttpPatch("Wallet/{walletId}/Balance/Increase/Approve")]
        public async Task<IActionResult> ChefApprove([FromBody] ApproveCommand chefApprove , CancellationToken ct)
        {

            var result = await _mediator.Send(chefApprove);

            await _unitOfWork.AddEventSourcesCommit(ct);

            return Ok($"Wallet {result.WalletId} Charged Successfully ! ");

        }
    }
}
