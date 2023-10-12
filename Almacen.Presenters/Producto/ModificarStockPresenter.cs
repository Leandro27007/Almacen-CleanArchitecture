using Almacen.CasosDeUsoPorts.OutputPorts.Producto;

namespace Almacen.Presenters.Producto
{
    public class ModificarStockPresenter : IModificarStockOutputPort, IPresenter<bool>
    {
        public bool Contenido { get; private set; }

        public Task ModificarStock(bool stockModificado)
        {
            Contenido = stockModificado;

            return Task.CompletedTask;
        }
    }
}
