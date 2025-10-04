using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline
{
    public class ChargeBalanceOfflineCommandValidator :AbstractValidator<ChargeBalanceOfflineCommand>
    {
        public ChargeBalanceOfflineCommandValidator()
        {
            RuleFor(x=>x.Amount).NotEmpty().WithMessage("Please Enter The Amount You Want To Charge !")
                .GreaterThan(100000).WithMessage("Amount Must Be More Than 100000IRR");

            
        }
    }
}
