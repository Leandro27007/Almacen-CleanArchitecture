using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.DTOs.Producto
{
    public class ProductoDTO
    {
        public string IdProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public int Cantidad { get; set; }
        public string NombreCategoria { get; set; }
        public int IdCategoria { get; set; }
    }
}
