using Almacen.CasosDeUsoPorts.InputPorts;
using Almacen.CasosDeUsoPorts.OutputPorts.Producto;
using Almacen.DTOs.Producto;
using Almacen.Presenters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoInputPort _inputPort;
        private readonly ICrearProductoOutputPort _crearProductoOutputPort;
        private readonly IBuscarProductoOutputPort _buscarProductoOutputPort;
        private readonly IListarProductosOutputPorts _listarProductosOutputPorts;
        private readonly IModificarStockOutputPort _modificarStockOutputPort;
        private readonly IEliminarProductoOutputPort _eliminarProductoOutputPort;
        private readonly IEditarProductoOutputPort _editarProductoOutputPort;
        public ProductoController(IProductoInputPort inputPort,
                                  ICrearProductoOutputPort crearProductoOutputPort,
                                  IBuscarProductoOutputPort buscarProductoOutputPort,
                                  IListarProductosOutputPorts listarProductosOutputPorts,
                                  IModificarStockOutputPort modificarStockOutputPort,
                                  IEliminarProductoOutputPort eliminarProductoOutputPort,
                                  IEditarProductoOutputPort editarProductoOutputPort)
        {
            this._inputPort = inputPort;
            this._crearProductoOutputPort = crearProductoOutputPort;
            this._buscarProductoOutputPort = buscarProductoOutputPort;
            this._listarProductosOutputPorts = listarProductosOutputPorts;
            this._modificarStockOutputPort = modificarStockOutputPort;
            this._eliminarProductoOutputPort = eliminarProductoOutputPort;
            this._editarProductoOutputPort = editarProductoOutputPort;
        }

        [HttpPost("Crear")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductoDTO>> CrearProducto([FromBody] CrearProductoDTO modelo)
        {
            try
            {
                await _inputPort.CrearProductoHandle(modelo);

                return Ok(((IPresenter<ProductoDTO>)_crearProductoOutputPort).Contenido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Buscar{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ProductoDTO>> Buscar(string id)
        {
            try
            {
                await _inputPort.BuscarProductoHandle(id);

                var producto = ((IPresenter<ProductoDTO>)_buscarProductoOutputPort).Contenido;

               return producto != null? Ok(producto) : NotFound("No se encontro el producto");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Editar{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductoDTO>> EditarProducto([FromBody] EditarProductoDTO modelo)
        {
            try
            {
                await _inputPort.EditarProductoHandle(modelo);

                var producto = ((IPresenter<bool>)_editarProductoOutputPort).Contenido;

                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ModificarStock")]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductoDTO>> ModificarStock([FromBody] ModificarStockDTO modelo)
        {
            try
            {
                await _inputPort.ModificarStock(modelo);

                var producto = ((IPresenter<bool>)_modificarStockOutputPort).Contenido;

                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Eliminar{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductoDTO>> EliminarProducto(string id)
        {
            try
            {
                await _inputPort.EliminarProductoHandle(id);

                var seElimino = ((IPresenter<bool>)_eliminarProductoOutputPort).Contenido;

                return seElimino? Ok($"{seElimino}: Se elimino el producto correctamente"): NotFound("Producto no encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("ListarTodo")]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> ListarProductos()
        {
            try
            {
                await _inputPort.ListarProductoHandle();

                var productos = ((IPresenter<IEnumerable<ProductoDTO>>)_listarProductosOutputPorts).Contenido;

                return productos.Count() > 0 ? Ok(productos) : NotFound("No se encontro ningun producto para listar");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
