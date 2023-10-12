using Almacen.CasosDeUsoPorts.OutputPorts.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Presenters.Producto
{
    public class EditarProductoPresenter : IEditarProductoOutputPort, IPresenter<bool>
    {
        public bool Contenido {  get; private set; }

        public Task EditarProductoHandle(bool productoEditado)
        {
            Contenido = productoEditado;

            return Task.CompletedTask;
        }
    }
}
