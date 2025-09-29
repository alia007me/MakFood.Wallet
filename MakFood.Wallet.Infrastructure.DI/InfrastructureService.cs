using MakFood.Wallet.Application.Contracts;
using MakFood.Wallet.Infrastructure.Context;
using MakFood.Wallet.Infrastructure.Repositories.Repositories;
using MakFood.Wallet.Infrastructure.Repositories.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.DI
{
    public static class InfrastructreService
    {
        public static IServiceCollection ConfigureInfrastructreServices(this IServiceCollection services)
        {
            services.AddDbContext<MakFoodWalletDbContext>(
                options => options.UseSqlServer("Server=.;Database=MakFood.Wallet2;Trusted_Connection=True;TrustServerCertificate=True"));
            services.AddHttpClient();
            services.AddScoped<IChargeRepository, ChargeRepository>();
            services.AddScoped<IZarinpalGateway,ZarinpalGateway>();


            return services;
        }

    }
}
