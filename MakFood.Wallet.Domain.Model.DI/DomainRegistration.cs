using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Services;
using MakFood.Wallet.Domain.Model.Services.Contract;
using MakFood.Wallet.Infrastructure.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.DI
{
    public static class DomainRegistration
    {
        public static IServiceCollection DomainServiceRegistration(this IServiceCollection services)
        {

            services.AddScoped<IOfflineTransactionNumberGenerator, OfflineTransactionNumberGenerator>();
            services.AddScoped<IReplyEventRepository, ReplyEventRepository>();
           // services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
            services.AddScoped<IDicoountCodeRepository, DicoountCodeRepository>();

            return services;
        }
    }
}
