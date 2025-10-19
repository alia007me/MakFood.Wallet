using MakFood.Wallet.Application.CommandHandlers.Base;
using MakFood.Wallet.Application.CommandHandlers.Base.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.QueryHandlers.replyEvent
{
    public class ReplyEventQuery : QueryBase, IRequest<ReplyEventQueryResponse>
    {
        public Guid guid { get; set; }
        public DateTime time { get; set; }

        public override void Validate()
        {
            new ReplyEventQueryValidator().Validate(this).ThrowIfNeeded();
        }
    }
}
