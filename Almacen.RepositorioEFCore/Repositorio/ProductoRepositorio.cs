using Almacen.Entitites.Entities;
using Almacen.Entitites.Interfaces;
using Almacen.RepositorioEFCore.Context;

namespace Almacen.RepositorioEFCore.Repositorio
{
    public class ProductoRepositorio : RepositorioGenerico<Producto, string>, IProductoRepositorio
    {
        public ProductoRepositorio(AlmacenDbContext db) : base(db)
        {}


    }
}
