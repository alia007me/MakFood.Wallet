using MakFood.Wallet.Domain.Model.Base;
using MakFood.Wallet.Infrastructure.Substructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MakFoodWalletDbContext _context;

        public UnitOfWork(MakFoodWalletDbContext context)
        {
            _context = context;
        }
        public async Task<int> Commit(CancellationToken ct) {
            return await _context.SaveChangesAsync(ct);
        }

        public async Task<int> AddEventSourcesCommit(CancellationToken ct)
        {
            AddEventSources();
            return await _context.SaveChangesAsync(ct);
                
        }

        private void AddEventSources()
        {
            var entries = _context.ChangeTracker.Entries();
            /*.Where(x=>x.State!=Microsoft.EntityFrameworkCore.EntityState.Unchanged)*/

            entries.Where(entry => entry.Entity is IEventSourcedEntity)
                .Select(entry => entry.Entity as IEventSourcedEntity)
                .Foreach(eventSourceEntity =>
                {
                    eventSourceEntity!.Events.Foreach(@event =>
                    {
                        var eventSource = EventSource.Create(@event, eventSourceEntity.WalletId);

                        _context.WalletEvents.Add(eventSource);
                    });
                });

        }
    }
}
