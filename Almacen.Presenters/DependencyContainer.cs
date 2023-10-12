using Almacen.CasosDeUsoPorts.OutputPorts.Categoria;
using Almacen.CasosDeUsoPorts.OutputPorts.Producto;
using Almacen.Presenters.Categoria;
using Almacen.Presenters.Producto;
using Microsoft.Extensions.DependencyInjection;

namespace Almacen.Presenters
{
    public static class DependencyContainer
    {

        public static IServiceCollection AddPresentersService(this IServiceCollection services)
        {
            services.AddScoped<ICrearProductoOutputPort, CrearProductoPresenter>();
            services.AddScoped<IModificarStockOutputPort, ModificarStockPresenter>();
            services.AddScoped<IEditarProductoOutputPort, EditarProductoPresenter>();
            services.AddScoped<IEliminarProductoOutputPort, EliminarProductoPresenter>();
            services.AddScoped<IListarProductosOutputPorts, ListarProductosPresenter>();
            services.AddScoped<IBuscarProductoOutputPort, BuscarProductoPresenter>();

            services.AddScoped<ICrearCategoriaOutputPort, CrearCategoriaPresenter>();
            services.AddScoped<IEditarCategoriaOutputPort, EditarCategoriaPresenter>();
            services.AddScoped<IEliminarCategoriaOutputPort, EliminarCategoriaPresenter>();
            services.AddScoped<IListarCategoriasOutputPort, ListarCategoriaPresenter>();


            return services;
        }
    }
}
