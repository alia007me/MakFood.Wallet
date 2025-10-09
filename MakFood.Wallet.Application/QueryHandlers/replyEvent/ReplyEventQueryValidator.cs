using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.QueryHandlers.replyEvent
{
    public class ReplyEventQueryValidator : AbstractValidator<ReplyEventQuery>
    {
        public ReplyEventQueryValidator()
        {
            RuleFor(x => x.guid).NotEmpty().WithMessage("Chekar mikini");
            RuleFor(x => x.time).NotEmpty().WithMessage("chikar mikoni");

        }
    }
}
