using Almacen.CasosDeUsoPorts.InputPorts;
using Almacen.CasosDeUsoPorts.OutputPorts.Categoria;
using Almacen.CasosDeUsoPorts.OutputPorts.Producto;
using Almacen.DTOs.Categoria;
using Almacen.DTOs.Producto;
using Almacen.Entitites.Entities;
using Almacen.Entitites.Interfaces;

namespace Almacen.CasosDeUsos
{
    public class ProductoCasosDeUso : IProductoInputPort
    {

        private readonly IProductoRepositorio _repositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICrearProductoOutputPort _crearProductoOutputPort;
        private readonly IEditarProductoOutputPort _editarProductoOutputPort;
        private readonly IBuscarProductoOutputPort _buscarProductoOutputPort;
        private readonly IListarProductosOutputPorts _listarProductosOutputPorts;
        private readonly IModificarStockOutputPort _modificarStockOutputPort;
        private readonly IEliminarProductoOutputPort _eliminarProductoOutputPort;
        public ProductoCasosDeUso(IProductoRepositorio repositorio,
                                  IUnitOfWork unitOfWork,
                                  ICrearProductoOutputPort crearProductoOutputPort,
                                  IEditarProductoOutputPort editarProductoOutputPort,
                                  IBuscarProductoOutputPort buscarProductoOutputPort,
                                  IListarProductosOutputPorts listarProductosOutputPorts,
                                  IModificarStockOutputPort modificarStockOutputPort,
                                  IEliminarProductoOutputPort eliminarProductoOutputPort
                                  )
        {
            this._repositorio = repositorio;
            this._unitOfWork = unitOfWork;
            this._buscarProductoOutputPort = buscarProductoOutputPort;
            this._editarProductoOutputPort = editarProductoOutputPort;
            this._listarProductosOutputPorts = listarProductosOutputPorts;
            this._modificarStockOutputPort = modificarStockOutputPort;
            this._eliminarProductoOutputPort = eliminarProductoOutputPort;
            this._crearProductoOutputPort = crearProductoOutputPort;
        }

        public async Task ModificarStock(ModificarStockDTO modificarStockDTO)
        {
            var producto = _repositorio.BuscarPorId(modificarStockDTO.IdProducto);
            if (producto != null)
            {
                producto.Cantidad = modificarStockDTO.Cantidad;

                _repositorio.Editar(producto);
                await _unitOfWork.GuardarCambios();

                await _modificarStockOutputPort.ModificarStock(true);

                return;
            }

            await _modificarStockOutputPort.ModificarStock(false);
        }


        public async Task BuscarProductoHandle(string Id)
        {

            var producto = _repositorio.Consulta().Select(p => new ProductoDTO()
            {
                IdProducto = p.Id,
                Nombre = p.Nombre,
                Cantidad = p.Cantidad,
                IdCategoria = p.CategoriaID,
                NombreCategoria = p.Categoria.Nombre
            }).Where(p => p.IdProducto == Id).FirstOrDefault();

            await _buscarProductoOutputPort.BuscarProductoHandle(producto);

        }

        public async Task CrearProductoHandle(CrearProductoDTO agregarProductoDTO)
        {

            Producto producto = new Producto()
            {
                Id = agregarProductoDTO.IdProducto,
                Nombre = agregarProductoDTO.Nombre,
                Cantidad = agregarProductoDTO.Cantidad,
                CategoriaID = agregarProductoDTO.IdCategoria

            };

            var productoCreado = _repositorio.Agregar(producto);
            try
            {
                await _unitOfWork.GuardarCambios();

            }
            catch (Exception ex)
            {

                throw;
            }

            await _crearProductoOutputPort.CrearProductoHandle(new ProductoDTO()
            {
                IdProducto = productoCreado.Id,
                Nombre = productoCreado.Nombre,
                Cantidad = productoCreado.Cantidad,
                IdCategoria = productoCreado.CategoriaID
            });

        }

        public async Task EditarProductoHandle(EditarProductoDTO editarProductoDTO)
        {

            _repositorio.Editar(new Producto()
            {
                Id = editarProductoDTO.IdProducto,
                Nombre = editarProductoDTO.Nombre,
                Cantidad = editarProductoDTO.Cantidad,
                CategoriaID = editarProductoDTO.IdCategoria
            });

            bool seEdito = await _unitOfWork.GuardarCambios() > 0 ? true : false;

            await _editarProductoOutputPort.EditarProductoHandle(seEdito);

        }

        public async Task EliminarProductoHandle(string Id)
        {
            _repositorio.EliminarPorId(Id);

            bool seElimino = await _unitOfWork.GuardarCambios() > 0 ? true : false;

            await _eliminarProductoOutputPort.EliminarProductoHandle(seElimino);
        }

        public async Task ListarProductoHandle()
        {
            var productos = _repositorio.Consulta().Select(p => new ProductoDTO()
            {
                IdProducto = p.Id,
                Nombre = p.Nombre,
                Cantidad = p.Cantidad,
                IdCategoria = p.CategoriaID,
                NombreCategoria = p.Categoria.Nombre
            }).ToList();

            await _listarProductosOutputPorts.ListarProductoHandle(productos);
        }

    }
}
