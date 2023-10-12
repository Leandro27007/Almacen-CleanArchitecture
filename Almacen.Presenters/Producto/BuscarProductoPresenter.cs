using Almacen.CasosDeUsoPorts.OutputPorts.Producto;
using Almacen.DTOs.Producto;

namespace Almacen.Presenters.Producto
{
    public class BuscarProductoPresenter : IBuscarProductoOutputPort, IPresenter<ProductoDTO?>
    {
        public ProductoDTO? Contenido { get; private set; }

        public Task BuscarProductoHandle(ProductoDTO? productoDTO)
        {
            Contenido = productoDTO;
            return Task.CompletedTask;
        }
    }
}
