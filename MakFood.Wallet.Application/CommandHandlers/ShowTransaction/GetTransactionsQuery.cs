using System;
using System.Collections.Generic;
using MakFood.Wallet.Application.DTOs;
using MediatR;

namespace MakFood.Wallet.Application.Features.Payments.Queries
{
    public record GetTransactionsQuery(Guid walletId) : IRequest<List<TransaactionDto>>;
}