using Azure;
using FluentValidation;
using MakFood.Wallet.Application.CommandHandlers.AddOrderDeatails;
using MakFood.Wallet.Application.CommandHandlers.AddWalet;
using MakFood.Wallet.Application.CommandHandlers.Base;
using MakFood.Wallet.Application.CommandHandlers.Base.Extensions;
using MakFood.Wallet.Application.CommandHandlers.PayOrderDeatails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers
{
    public class PayOrderDeatailComandvalidator : AbstractValidator<PayOrderDeatailComand>
    {
        public PayOrderDeatailComandvalidator()
        {
            RuleFor(X => X.WalletID).NotEmpty().NotNull();
            RuleFor(X => X.OrdearDeataisID).NotEmpty().NotNull();
        } 
    }
}
