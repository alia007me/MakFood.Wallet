using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ZarinpalPayRequest
{
    public class ZarinpalPayRequestCommandValidator : AbstractValidator<ZarinpalPayRequestCommand>
    {
        public ZarinpalPayRequestCommandValidator()
        {
            RuleFor(x => x.Amount).NotEmpty().WithMessage("Please Enter The Amount You Want To Charge !")
        .GreaterThan(100000).WithMessage("Amount Must Be More Than 100000IRR");

            RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("Email shouldn't be empty")
                    .EmailAddress().WithMessage("Invalid email format")
                     .Matches(@"^[^@\s]+@gmail\.com$").WithMessage("Only Gmail addresses are allowed");
        }
    }
}
