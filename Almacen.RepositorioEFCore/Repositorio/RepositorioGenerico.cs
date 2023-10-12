using Almacen.Entitites.Entities;
using Almacen.Entitites.Interfaces;
using Almacen.RepositorioEFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace Almacen.RepositorioEFCore.Repositorio
{
    public class RepositorioGenerico<T,TipoDatoId> : IRepositorioGenerico<T, TipoDatoId> where T : Entidad<TipoDatoId>, new()
    {
        private readonly AlmacenDbContext _db;
        readonly DbSet<T> dbSet;
        public RepositorioGenerico(AlmacenDbContext db)
        {
            this._db = db;
            dbSet = db.Set<T>();
        }



        public T Agregar(T obj)
        {
            _db.Add(obj);
            return obj;
        }

        public T? BuscarPorId(TipoDatoId Id)
        {
            var entidad = dbSet.FirstOrDefault(p => p.Id.Equals(Id));

            return entidad;
        }

        public IQueryable<T> Consulta()
        {
            return dbSet.AsQueryable();
        }

        public void Editar(T obj)
        {
            dbSet.Update(obj);
        }

        public void EliminarPorId(TipoDatoId Id)
        {
            T entidad = new T();
            entidad.Id = Id;
            _db.Attach(entidad);

            dbSet.Remove(entidad);
        }

        public IEnumerable<T> Listar()
        {
            return dbSet.ToList();
        }
    }
}
