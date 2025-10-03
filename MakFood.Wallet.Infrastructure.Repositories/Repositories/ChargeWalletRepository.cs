using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Repositories.Repositories
{
    public class ChargeWalletRepository : IChargeWalletRepository
    {
        private readonly MakFoodWalletDbContext _context;

        public ChargeWalletRepository(MakFoodWalletDbContext context)
        {
            _context = context;
        }


        public async Task<Domain.Model.Entities.Wallet> GetWalletById(Guid Id,CancellationToken ct)
        {
            return await _context.Wallets.SingleOrDefaultAsync(x => x.WalletId == Id,ct);
        }
    }
}
