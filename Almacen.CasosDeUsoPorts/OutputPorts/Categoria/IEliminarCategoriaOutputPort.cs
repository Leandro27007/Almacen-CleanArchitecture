using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.CasosDeUsoPorts.OutputPorts.Categoria
{
    public interface IEliminarCategoriaOutputPort
    {
        Task Handle(bool seElimino);
    }
}
