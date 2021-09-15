using CurrencyConverter.Services.Concrete;
using CurrencyConverter.Services.Contract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    public static class LibModule
    {
        public static void RegisterTypes(IServiceCollection services)
        {

            /* Services */
            services.AddScoped<IRateService, RateService>();

        }
    }
}
