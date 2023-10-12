namespace Almacen.DTOs.Producto
{
    public class CrearProductoDTO
    {

        public string IdProducto { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int Cantidad { get; set; }
        public int IdCategoria { get; set; }
    }
}
