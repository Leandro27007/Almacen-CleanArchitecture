using Almacen.CasosDeUsoPorts.InputPorts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.CasosDeUsos
{
    public static class DependencyContainer
    {


        public static IServiceCollection AddCasosDeUsoService(this IServiceCollection services)
        {

            services.AddScoped<IProductoInputPort, ProductoCasosDeUso>();
            services.AddScoped<ICategoriaInputPort, CategoriaCasoDeUso>();

            return services;
        }

    }
}
