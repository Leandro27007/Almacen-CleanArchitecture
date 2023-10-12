using Almacen.Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Entitites.Interfaces
{
    public interface IRepositorioGenerico<T, TipoDatoId> where T : Entidad<TipoDatoId>
    {
        T Agregar(T obj);
        void Editar(T obj);
        IEnumerable<T> Listar();
        T? BuscarPorId(TipoDatoId Id);
        void EliminarPorId(TipoDatoId Id);
        IQueryable<T> Consulta();
    }
}
