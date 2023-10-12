using Almacen.Entitites.Interfaces;
using Almacen.RepositorioEFCore.Context;

namespace Almacen.RepositorioEFCore.Repositorio
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AlmacenDbContext _db;
        public UnitOfWork(AlmacenDbContext db)
        {
                this._db = db;
        }

        public async Task<int> GuardarCambios()
        {
            try
            {
                return await _db.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
