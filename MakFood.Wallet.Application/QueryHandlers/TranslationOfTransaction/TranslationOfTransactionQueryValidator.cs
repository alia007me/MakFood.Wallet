using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MakFood.Wallet.Application.QueryHandlers.Transaction
{
    public class TranslationOfTransactionQueryValidator : AbstractValidator<TranslationOfTransactionQuery>
    {

        public TranslationOfTransactionQueryValidator() 
        {
            RuleFor(x => x.WalletId).NotEmpty().WithMessage("Chekar mikini");
            RuleFor(x => x.dateTime).NotEmpty().WithMessage("chikar mikoni");
        }
       


    }


}