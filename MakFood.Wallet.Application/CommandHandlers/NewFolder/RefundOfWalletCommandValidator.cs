using FluentValidation;
using MakFood.Wallet.Application.CommandHandlers.RefundOfWallet;

namespace Application.Commands.WithdrawWallet
{
    public class RefundOfWalletCommandValidator : AbstractValidator<RefundOfWalletCommand>
    {
        public RefundOfWalletCommandValidator()
        {
            RuleFor(x => x.WalletId)
                .NotEmpty().WithMessage("WalletId is null ");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than zero.");

        }
    }
}