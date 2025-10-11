using MakFood.Wallet.Domain.Model.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Context.Configurations
{
    public class EventSourceConfiguration : IEntityTypeConfiguration<EventSource>
    {
        public void Configure(EntityTypeBuilder<EventSource> builder)
        {
            builder.HasKey(x=>x.Id);
            
        }
    }
}
