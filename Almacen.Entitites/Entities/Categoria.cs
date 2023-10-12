namespace Almacen.Entitites.Entities
{
    public class Categoria : Entidad<int>
    {
        public string Nombre { get; set; } = null!;
        public IEnumerable<Producto> Productos { get; set; } = new List<Producto>();
    }
}
