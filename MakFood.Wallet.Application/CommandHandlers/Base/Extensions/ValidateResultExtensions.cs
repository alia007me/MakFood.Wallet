using FluentValidation.Results;
using MakFood.Wallet.Infrastructure.Substructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.Base.Extensions
{
    public static class ValidationResultExtensions
    {
        public static void ThrowIfNeeded(this ValidationResult validationResult)
        {
            var errors = validationResult.Errors;

            if (errors.Any())
                throw new BadRequestException(string.Join(Environment.NewLine, errors.Select(e => e.ErrorMessage)));
        }
    }
}
