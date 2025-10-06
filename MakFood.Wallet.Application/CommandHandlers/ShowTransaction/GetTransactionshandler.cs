using MakFood.Wallet.Application.Contracts;
using MakFood.Wallet.Application.DTOs;
using MakFood.Wallet.Application.Features.Payments.Queries;
using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Infrastructure.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MakFood.Wallet.Application.

namespace MakFood.Wallet.Application.Features.Payments.Handlers
{
    public class GetTransactionshandler : IRequestHandler<GetTransactionsQuery, List<TransaactionDto>>
    {
        private readonly IShowTransactionRepository _showTransactionRepository;

        public GetTransactionshandler(IShowTransactionRepository showTransactionRepository)
        {
            _showTransactionRepository = showTransactionRepository;
        }

        public async Task<List<TransaactionDto>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _showTransactionRepository.GetByWalletIdAsync(request.walletId);

            var dtos = transactions.Select(t => new TransaactionDto
            {
                Id = t.WalletId,
                Amount = t.Amount,
                Created = t.DateTime,
                TrackingCode = t.TransactionNumber,
                TransactionType = t.GetType().Name,
            }).ToList();

            return dtos;
        }
    }
}