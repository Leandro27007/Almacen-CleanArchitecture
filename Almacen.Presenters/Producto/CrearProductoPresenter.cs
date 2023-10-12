using Almacen.CasosDeUsoPorts.OutputPorts.Producto;
using Almacen.DTOs.Producto;

namespace Almacen.Presenters.Producto
{
    public class CrearProductoPresenter : ICrearProductoOutputPort, IPresenter<ProductoDTO>
    {
        public ProductoDTO Contenido { get; private set; }

        public Task CrearProductoHandle(ProductoDTO productoDTO)
        {
            Contenido = productoDTO;
            return Task.CompletedTask;
        }
    }
}
