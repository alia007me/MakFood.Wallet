using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ZarinpalVerify
{
    public class ZarinpalVerifyCommandValidator : AbstractValidator<ZarinpalVerifyCommand>
    {

        public ZarinpalVerifyCommandValidator()
        {
            RuleFor(x => x.authority).NotEmpty().WithMessage("Authority Should Not Be Empty");
        }
    }
}
