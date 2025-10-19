using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.RobertInaroAzAvalBiar
{
    public class RobertInaroAzAvalBiarCommandValidator : AbstractValidator<RobertInaroAzAvalBiarCommand>
    {
        public RobertInaroAzAvalBiarCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Robert Kheily Khari");
        }
    }
}
