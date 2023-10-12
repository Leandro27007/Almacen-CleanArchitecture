using Almacen.RepositorioEFCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Almacen.RepositorioEFCore.FabricaTiempoDeDiseno
{
    public class AlmacenContextFabrica : IDesignTimeDbContextFactory<AlmacenDbContext>
    {
        public AlmacenDbContext CreateDbContext(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<AlmacenDbContext>();

            optionsBuilder.UseSqlServer("Server=localhost; database=AlmacenCA; Integrated Security= true; TrustServerCertificate=true;");

            return new AlmacenDbContext(optionsBuilder.Options);
        }
    }
}