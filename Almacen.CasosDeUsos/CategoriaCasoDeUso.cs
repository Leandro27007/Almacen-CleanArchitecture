using Almacen.CasosDeUsoPorts.InputPorts;
using Almacen.CasosDeUsoPorts.OutputPorts.Categoria;
using Almacen.DTOs.Categoria;
using Almacen.Entitites.Entities;
using Almacen.Entitites.Interfaces;

namespace Almacen.CasosDeUsos
{
    public class CategoriaCasoDeUso : ICategoriaInputPort
    {
        private readonly ICategoriaRepositorio _repositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICrearCategoriaOutputPort _crearCategoriaOutputPort;
        private readonly IEliminarCategoriaOutputPort _eliminarCategoriaOutputPort;
        private readonly IEditarCategoriaOutputPort _editarCategoriaOutputPort;
        private readonly IListarCategoriasOutputPort _listarCategoriaOutputPort;

        public CategoriaCasoDeUso(ICategoriaRepositorio repositorio,
                                  IUnitOfWork unitOfWork,
                                  ICrearCategoriaOutputPort crearCategoriaOutputPort,
                                  IEliminarCategoriaOutputPort eliminarCategoriaOutputPort,
                                  IEditarCategoriaOutputPort editarCategoriaOutputPort,
                                  IListarCategoriasOutputPort listarCategoriaOutputPort
                                  )
        {
            this._repositorio = repositorio;
            this._unitOfWork = unitOfWork;
            this._crearCategoriaOutputPort = crearCategoriaOutputPort;
            this._eliminarCategoriaOutputPort = eliminarCategoriaOutputPort;
            this._editarCategoriaOutputPort = editarCategoriaOutputPort;
            this._listarCategoriaOutputPort = listarCategoriaOutputPort;
        }


        public async Task CrearCategoriaHandle(CrearCategoriaDTO crearCategoriaDTO)
        {
            var categoria = _repositorio.Agregar(new Categoria()
            {
                Nombre = crearCategoriaDTO.Nombre
            });

            await _unitOfWork.GuardarCambios();

            await _crearCategoriaOutputPort.Handle(new CategoriaDTO()
            {
                IdCategoria = categoria.Id,
                Nombre = categoria.Nombre
            });

        }

        public async Task EditarCategoriaHandle(EditarCategoriaDTO editarCategoriaDTO)
        {

            if (editarCategoriaDTO.Id <= 0)
            {
                throw new IOException("El id debe ser mayor a 0");
            }

            _repositorio.Editar(new Categoria()
            {
                Id = editarCategoriaDTO.Id,
                Nombre = editarCategoriaDTO.Nombre
            });

            bool seElimino = await _unitOfWork.GuardarCambios() > 0 ? true : false;

            await _editarCategoriaOutputPort.Handle(seElimino);

        }

        public async Task EliminarCategoriaHandle(int Id)
        {
            _repositorio.EliminarPorId(Id);

            bool seElimino = await _unitOfWork.GuardarCambios() > 0 ? true : false;

            await _eliminarCategoriaOutputPort.Handle(seElimino);

        }

        public async Task ListarCategoriasHandle()
        {
            var categorias = _repositorio.Listar().Select(c => new CategoriaDTO()
            {
                IdCategoria = c.Id,
                Nombre = c.Nombre
            });

            await _listarCategoriaOutputPort.Handle(categorias);
        }
    }
}
