using Almacen.CasosDeUsoPorts.OutputPorts.Categoria;
using Almacen.DTOs.Categoria;

namespace Almacen.Presenters.Categoria
{
    public class ListarCategoriaPresenter : IListarCategoriasOutputPort, IPresenter<IEnumerable<CategoriaDTO>>
    {
        public IEnumerable<CategoriaDTO> Contenido {  get; private set; }

        public Task Handle(IEnumerable<CategoriaDTO> categorias)
        {
            Contenido = categorias;

            return Task.CompletedTask;
        }
    }
}
