namespace Almacen.Entitites.Entities
{
    public class Producto : Entidad<string>
    {
        public string Nombre { get; set; } = null!;
        public int Cantidad { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int CategoriaID { get; set; }
    }
}
