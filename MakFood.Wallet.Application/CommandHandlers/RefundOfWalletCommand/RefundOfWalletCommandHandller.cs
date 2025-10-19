using MakFood.Wallet.Application.CommandHandlers.RefundOfWallet;
using MakFood.Wallet.Domain.Model.Contracts;

namespace Application.Commands.WithdrawWallet
{
    public class RefundOfWalletCommandHandller
    {
        private readonly IWalletRepository _walletRepository;

        public RefundOfWalletCommandHandller(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<RefundOfWalletCommandResponse> HandleAsync(RefundOfWalletCommand command)
        {
            if (command.WalletId == Guid.Empty)
                return RefundOfWalletCommandResponse.Fail("WalletId is null");

            if (command.Amount <= 0)
                return RefundOfWalletCommandResponse.Fail("Amount must be greater than zero");

            var wallet = await _walletRepository.GetByWalletIdAsync(command.WalletId);
            if (wallet == null)
                return RefundOfWalletCommandResponse.Fail("Wallet not found.");

            try
            {
             
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
                return RefundOfWalletCommandResponse.Fail("Failure");
            }
        }
    }
}