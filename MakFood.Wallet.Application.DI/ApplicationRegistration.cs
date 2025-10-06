using FluentValidation;
using MakFood.Wallet.Application.CommandHandlers.ChargeBalanceOnline;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
            });
            services.AddValidatorsFromAssemblyContaining<ChargeBalanceOnlineCommandValidator>();

            return services;
        }

    }
}
