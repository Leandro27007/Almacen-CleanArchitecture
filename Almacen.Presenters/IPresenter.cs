namespace Almacen.Presenters
{
    public interface IPresenter<TipoDatoContenido>
    {
        public TipoDatoContenido Contenido { get; }
    }
}
