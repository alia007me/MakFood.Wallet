
using FluentValidation;

namespace MakFood.Wallet.Application.CommandHandlers.AddWalet
{
    public class AddWalletCommandValidator : AbstractValidator<AddWalletCommand>
    {
        public AddWalletCommandValidator()
        {
            RuleFor(x => x.CustumerID).NotEmpty().NotNull().WithMessage("it's cant be empty");
        }
    }
}
