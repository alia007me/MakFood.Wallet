using FluentValidation;
using MakFood.Wallet.Application.Features.Payments.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ShowTransaction
{
    public class GetTransactionsQueryValidator : AbstractValidator<GetTransactionsQuery>
    {

    }
}