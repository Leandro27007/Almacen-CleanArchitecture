using Almacen.DTOs.Producto;

namespace Almacen.CasosDeUsoPorts.InputPorts
{
    public interface IProductoInputPort
    {
        Task ModificarStock(ModificarStockDTO agregarProductoDTO);
        Task CrearProductoHandle(CrearProductoDTO agregarProductoDTO);
        Task EditarProductoHandle(EditarProductoDTO agregarProductoDTO);
        Task EliminarProductoHandle(string Id);
        Task BuscarProductoHandle(string Id);
        Task ListarProductoHandle();

    }
}
