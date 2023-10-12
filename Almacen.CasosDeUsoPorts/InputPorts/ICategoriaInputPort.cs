using Almacen.DTOs.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.CasosDeUsoPorts.InputPorts
{
    public interface ICategoriaInputPort
    {
        Task CrearCategoriaHandle(CrearCategoriaDTO crearCategoriaDTO);
        Task EditarCategoriaHandle(EditarCategoriaDTO editarCategoriaDTO);
        Task EliminarCategoriaHandle(int Id);
        Task ListarCategoriasHandle();
    }
}
