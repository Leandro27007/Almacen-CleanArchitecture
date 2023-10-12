using Almacen.CasosDeUsoPorts.OutputPorts.Producto;

namespace Almacen.Presenters.Producto
{
    public class EliminarProductoPresenter : IEliminarProductoOutputPort, IPresenter<bool>
    {
        public bool Contenido { get; private set; }

        public Task EliminarProductoHandle(bool productoEliminado)
        {
            Contenido = productoEliminado;

            return Task.CompletedTask;
        }
    }
}
