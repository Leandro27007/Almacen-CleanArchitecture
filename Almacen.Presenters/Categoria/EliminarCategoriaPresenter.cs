using Almacen.CasosDeUsoPorts.OutputPorts.Categoria;

namespace Almacen.Presenters.Categoria
{
    public class EliminarCategoriaPresenter : IEliminarCategoriaOutputPort, IPresenter<bool>
    {
        public bool Contenido {  get; private set; }

        public Task Handle(bool seElimino)
        {
            Contenido = seElimino;

            return Task.CompletedTask;
        }
    }
}
