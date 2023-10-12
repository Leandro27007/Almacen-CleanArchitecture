using Almacen.DTOs.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.CasosDeUsoPorts.OutputPorts.Categoria
{
    public interface ICrearCategoriaOutputPort
    {
        Task Handle(CategoriaDTO categoria);
    }
}
