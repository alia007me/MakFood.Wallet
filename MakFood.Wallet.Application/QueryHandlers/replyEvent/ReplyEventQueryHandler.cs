using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.QueryHandlers.replyEvent
{
    public class ReplyEventQueryHandler : IRequestHandler<ReplyEventQuery, ReplyEventQueryResponse>
    {
        public Task<ReplyEventQueryResponse> Handle(ReplyEventQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
