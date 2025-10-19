using MakFood.Wallet.Application.CommandHandlers.RefundOfWallet;
using MakFood.Wallet.Domain.Model.Contracts;

namespace Application.Commands.WithdrawWallet
{
    public class WithdrawWalletCommandHandler
    {
        private readonly IWalletRepository _walletRepository;

        public WithdrawWalletCommandHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<RefundOfWalletCommandResponse> HandleAsync(RefundOfWalletCommand command)
        {
            if (command.WalletId == Guid.Empty)
                return RefundOfWalletCommandResponse.Fail("WalletId is null" +
                    ".");

            if (command.Amount <= 0)
                return RefundOfWalletCommandResponse.Fail("Amount must be greater than zero.");

            var wallet = await _walletRepository.GetByUserIdAsync(command.WalletId);
            if (wallet == null)
                return RefundOfWalletCommandResponse.Fail("Wallet not found.");

            try
            {
                wallet.Withdraw(command.Amount);
                await _walletRepository.UpdateAsync(wallet);
                await _walletRepository.SaveChangesAsync();

                return RefundOfWalletCommandResponse.Ok(wallet.Balance);
            }
            catch (InvalidOperationException ex)
            {
                return RefundOfWalletCommandResponse.Fail(ex.Message);
            }
            catch (Exception)
            {
                return RefundOfWalletCommandResponse.Fail("An unexpected error occurred.");
            }
        }
    }
}