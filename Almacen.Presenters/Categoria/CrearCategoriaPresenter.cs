using Almacen.CasosDeUsoPorts.OutputPorts.Categoria;
using Almacen.DTOs.Categoria;

namespace Almacen.Presenters.Categoria
{
    public class CrearCategoriaPresenter : ICrearCategoriaOutputPort, IPresenter<CategoriaDTO>
    {
        public CategoriaDTO Contenido { get; private set; }

        public Task Handle(CategoriaDTO categoria)
        {
            Contenido = categoria;

            return Task.CompletedTask;
        }
    }
}
