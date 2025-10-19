using MakFood.Wallet.Domain.Model.Base;
using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Entities;
using MakFood.Wallet.Domain.Model.Enums;
using MakFood.Wallet.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MakFood.Wallet.Infrastructure.Repositories.Repositories
{
    public class ReplyEventRepository : IReplyEventRepository
    {
        private readonly MakFoodWalletDbContext _context;

        public ReplyEventRepository(MakFoodWalletDbContext context)
        {
            _context = context;
        }

        public async Task<List<EventSource>> GetWaletEvent(Guid id, DateTime time,CancellationToken ct)
        {
            var eventSources = await _context.WalletEvents.Where(c => c.OccurredDateTime <= time && c.WalletId == id)
                                                          .OrderBy(c => c.OccurredDateTime)
                                                          .ToListAsync(ct);
                                                    
            return eventSources;
        }
  

    }
}
