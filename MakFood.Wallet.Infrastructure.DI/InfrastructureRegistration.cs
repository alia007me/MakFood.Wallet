using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Infrastructure.Context;
using MakFood.Wallet.Infrastructure.Repositories.Repositories;
using MakFood.Wallet.Infrastructure.Substructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using MakFood.Wallet.Infrastructure.Repositories.ServiceContracts;
using MakFood.Wallet.Infrastructure.Repositories.Services;
using MakFood.Wallet.Domain.Model.Services.Contract;
using MakFood.Wallet.Domain.Model.Services;

namespace MakFood.Wallet.Infrastructure.DI
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<MakFoodWalletDbContext>(options =>
            {
                options.UseSqlServer("Server=.;Database=MakFood.Wallet3;Trusted_Connection=True;TrustServerCertificate=True");
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IChargeWalletRepository, ChargeWalletRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IZarinpalGateway, ZarinpalGateway>();
            services.AddScoped<IOfflineTransactionNumberGenerator,OfflineTransactionNumberGenerator>();
            services.AddScoped<IReplyEventRepository, ReplyEventRepository>();
            services.AddHttpClient();

            return services;
        }
    }
}
