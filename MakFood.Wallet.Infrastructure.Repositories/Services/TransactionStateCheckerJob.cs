using MakFood.Wallet.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Repositories.Services
{
    public class TransactionStateCheckerJob : IJob
    {
        private readonly MakFoodWalletDbContext _context;

        public TransactionStateCheckerJob(MakFoodWalletDbContext context)
        {
            _context = context;
        }
        
        public async Task Execute(IJobExecutionContext context)
        {
            var time = DateTime.Now.AddMinutes(-1);

            var expiredtransactions = await _context.Wallets
                .Include(x=>x.chargeTransactions)
                .SelectMany(x=>x.chargeTransactions)
                .Where(x=> x.ChargeState == Domain.Model.Enums.ChargeModelState.Pending && x.TransactionDate < time).ToListAsync();
                //(x => x.ChargeState == Domain.Model.Enums.ChargeModelState.Pending && x.TransactionDate < time).ToListAsync();

            if (expiredtransactions.Any())
            {
                _context.ChargeTransactions.RemoveRange(expiredtransactions);
                await _context.SaveChangesAsync();
            }


        }
    }
}
