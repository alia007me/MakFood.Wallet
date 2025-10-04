using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ChefApprove
{
    public class ChefApproveCommandValidator : AbstractValidator<ChefApproveCommand>
    {
        public ChefApproveCommandValidator()
        {
            RuleFor(x=>x.TransactionNumber).NotEmpty().WithMessage("Please Enter TransactionNumber")
                .Length(11).WithMessage("Invalid TransactionNumber Form");
        }
    }
}
