using FluentValidation;
using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOnline;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.PayOrderDetails
{
    public class PayOrderDetailsComandValidator : AbstractValidator<PayOrderDetailsComand>
    {
        public PayOrderDetailsComandValidator() 
        {
            RuleFor(x => x.OrderAmount).NotEmpty().WithMessage("it's can't be empty")
                                       .GreaterThan(0).WithMessage("it's not a valid amount");

        }
    }
}
