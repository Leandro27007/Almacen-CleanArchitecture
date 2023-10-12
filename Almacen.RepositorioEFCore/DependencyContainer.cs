using Almacen.Entitites.Interfaces;
using Almacen.RepositorioEFCore.Context;
using Almacen.RepositorioEFCore.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Almacen.RepositorioEFCore
{
    public static class DependencyContainer
    {

        public static IServiceCollection AddRepositorioService(this IServiceCollection services, IConfiguration configuracion)
        {

            services.AddDbContext<AlmacenDbContext>(options =>
                options.UseSqlServer(configuracion.GetConnectionString("Almacen")));

            services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

    }
}
