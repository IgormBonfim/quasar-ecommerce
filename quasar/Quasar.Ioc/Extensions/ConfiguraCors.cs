using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Quasar.Ioc.Extensions
{
    public static class ConfiguraCors
    {
        public static void ConfiguracoesCors(this IServiceCollection services)
        {
            services.AddCors(options => 
            {
                string dominio = "http://localhost:4200";
                options.AddDefaultPolicy(builder => builder.WithOrigins(dominio)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                );
            });
        }
    }
}