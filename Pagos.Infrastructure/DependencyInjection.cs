using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Pagos.Domain.Repositories;
using Pagos.Infrastructure.Repositories;
using Pagos.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Pagos.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfraestructure(
            this IServiceCollection services, string connectionString
            )
        {

            services.AddDataBaseFactories(connectionString);
            services.AddRepositories();

        }

        private static void AddDataBaseFactories(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<PagoDbContext>(
                options => options.UseSqlServer(connectionString)
            );

        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPagoRepository, PagoRepository>();

            
        }

    }
}
