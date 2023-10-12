using Almacen.CasosDeUsoPorts.OutputPorts.Producto;
using Almacen.DTOs.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Presenters.Producto
{
    public class ListarProductosPresenter : IListarProductosOutputPorts, IPresenter<IEnumerable<ProductoDTO>?>
    {
        public IEnumerable<ProductoDTO>? Contenido { get; private set; }
        
        public Task ListarProductoHandle(IEnumerable<ProductoDTO>? productosDTO)
        {
            Contenido = productosDTO;

            return Task.CompletedTask;  
        }
    }
}
