using Almacen.CasosDeUsoPorts.OutputPorts.Categoria;

namespace Almacen.Presenters.Categoria
{
    public class EditarCategoriaPresenter : IEditarCategoriaOutputPort, IPresenter<bool>
    {
        public bool Contenido {  get; private set; }

        public Task Handle(bool seEdito)
        {
            Contenido = seEdito;

            return Task.CompletedTask;
        }
    }
}
