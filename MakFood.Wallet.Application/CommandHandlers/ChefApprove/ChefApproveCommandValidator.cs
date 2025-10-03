using FluentValidation;
using FluentValidation.Validators;
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
            RuleFor(x => x.Amount).NotEmpty().GreaterThan(50000).WithMessage("Amount Shouldn't Be More Than 50000 !");
            
        }
    }
}
