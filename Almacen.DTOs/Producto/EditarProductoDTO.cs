using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.DTOs.Producto
{
    public class EditarProductoDTO
    {
        public string IdProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public int Cantidad { get; set; }
        public int IdCategoria { get; set; }

    }
}
