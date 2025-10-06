using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOnline
{
    public class ChargeBalanceOnlineCommandValidator:AbstractValidator<ChargeBalanceOnlineCommand>
    {
        public ChargeBalanceOnlineCommandValidator()
        {
            RuleFor(x => x.Write.Amount)
                .GreaterThan(50000).WithMessage("Amount must be greater than zero");

            RuleFor(x => x.Write.Email)
                .NotEmpty().WithMessage("Email shouldn't be empty")
                .EmailAddress().WithMessage("Invalid email format")
                .Matches(@"^[^@\s]+@gmail\.com$").WithMessage("Only Gmail addresses are allowed");

        }
    }
}
