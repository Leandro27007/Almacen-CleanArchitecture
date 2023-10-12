using Almacen.Entitites.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almacen.RepositorioEFCore.Context
{
    public class AlmacenDbContext : DbContext
    {
        public AlmacenDbContext(DbContextOptions<AlmacenDbContext> opciones) : base(opciones)
        { }


        public DbSet<Producto> Producto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

    }
}
