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
    public class PayOrderDeatailComand: CommandBase, IRequest<PayOrderDeatailComandRespone>
    {
        public Guid WalletID { get; set; }
        public Guid OrdearDeatais { get; set; }
        public override void Validate()
        {
            new PayOrderDeatailComandvalidator().Validate(this).ThrowIfNeeded();
        }
 
    }
}
