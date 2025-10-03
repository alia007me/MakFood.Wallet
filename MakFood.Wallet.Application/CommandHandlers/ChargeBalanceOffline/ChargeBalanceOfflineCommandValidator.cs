using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline
{
    public class ChargeBalanceOfflineCommandValidator : AbstractValidator<ChargeBalanceOfflineCommand>
    {
        public ChargeBalanceOfflineCommandValidator()
        {
            RuleFor(w => w.request.Amount).NotEmpty().GreaterThan(50000).WithMessage("Amount Should Be More Than 50000 !");
        }

    }
}
