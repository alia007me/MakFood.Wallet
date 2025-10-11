using MakFood.Wallet.Application.CommandHandlers.Base;
using MakFood.Wallet.Application.CommandHandlers.Base.Extensions;
using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.ChefApprove
{
    public class ApproveCommand : CommandBase,IRequest<ApproveCommandResponse>
    {
        public Guid Walletid { get; set; }
        public string TransactionNumber { get; set; }
        public string Approver {  get; set; }


        public override void Validate()
        {
        }

    }
}
