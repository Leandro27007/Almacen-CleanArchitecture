using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.DTOs.Producto
{
    public class ModificarStockDTO
    {
        public string IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
