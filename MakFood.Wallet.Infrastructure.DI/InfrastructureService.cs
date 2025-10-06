using MakFood.Wallet.Infrastructure.Context;
using MakFood.Wallet.Infrastructure.Repositories.Repositories;
using MakFood.Wallet.Infrastructure.Repositories.Services;
using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

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

            services.AddQuartz(q =>
            {


                var jobKey = new JobKey("CleanUpTransactionsJob");

                q.AddJob<TransactionStateCheckerJob>(opts => opts.WithIdentity(jobKey));

                q.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithIdentity("CleanUpTransactionsTrigger")
                    .WithSimpleSchedule(x => x.WithIntervalInMinutes(1).RepeatForever()));
            });
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = false);


            return services;
        }

    }
}
