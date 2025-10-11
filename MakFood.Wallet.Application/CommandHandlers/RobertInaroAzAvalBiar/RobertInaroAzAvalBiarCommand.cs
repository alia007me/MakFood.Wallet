using MakFood.Wallet.Application.CommandHandlers.Base;
using MakFood.Wallet.Application.CommandHandlers.Base.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.CommandHandlers.RobertInaroAzAvalBiar
{
    public class RobertInaroAzAvalBiarCommand : CommandBase, IRequest<RobertInaroAzAvalBiarCommandResponse>
    {
        public Guid Id { get; set; }
        public override void Validate()
        {
            new RobertInaroAzAvalBiarCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
