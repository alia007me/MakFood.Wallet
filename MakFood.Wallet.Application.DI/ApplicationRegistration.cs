using FluentValidation;
using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOffline;
using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOnline;
using MakFood.Wallet.Application.CommandHandlers.ChefApprove;
using MakFood.Wallet.Application.CommandHandlers.ZarinpalPayRequest;
using MakFood.Wallet.Application.CommandHandlers.ZarinpalVerify;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.DI
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection ConfigureApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ChargeBalanceOnlineCommandHandler).Assembly);
                cfg.RegisterServicesFromAssemblies(typeof(ChargeBalanceOfflineCommandHandler).Assembly);
                cfg.RegisterServicesFromAssemblies(typeof(ChefApproveCommandHandler).Assembly);
                cfg.RegisterServicesFromAssemblies(typeof(ZarinpalPayRequestCommandHandler).Assembly);
                cfg.RegisterServicesFromAssemblies(typeof(ZarinpalVerifyCommandHandler).Assembly);

            });

            services.AddValidatorsFromAssemblyContaining<ChargeBalanceOnlineCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<ChargeBalanceOfflineCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<ChefApproveCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<ZarinpalPayRequestCommandValidator>();



            return services;
        }

    }
}
