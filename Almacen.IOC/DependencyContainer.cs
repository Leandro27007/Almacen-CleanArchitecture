using Almacen.CasosDeUsos;
using Almacen.Presenters;
using Almacen.RepositorioEFCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.IOC
{
    public static class DependencyContainer
    {

        public static IServiceCollection AddAlmacenServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddRepositorioService(configuration);
            services.AddCasosDeUsoService();
            services.AddPresentersService();

            return services;
        }


    }
}
