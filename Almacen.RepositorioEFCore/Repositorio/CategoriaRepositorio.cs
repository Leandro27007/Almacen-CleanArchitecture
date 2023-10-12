using Almacen.Entitites.Entities;
using Almacen.Entitites.Interfaces;
using Almacen.RepositorioEFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.RepositorioEFCore.Repositorio
{
    public class CategoriaRepositorio : RepositorioGenerico<Categoria, int>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(AlmacenDbContext db) : base(db)
        {}


    }
}
