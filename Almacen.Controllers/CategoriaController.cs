using Almacen.CasosDeUsoPorts.InputPorts;
using Almacen.CasosDeUsoPorts.OutputPorts.Categoria;
using Almacen.CasosDeUsoPorts.OutputPorts.Producto;
using Almacen.DTOs.Categoria;
using Almacen.DTOs.Producto;
using Almacen.Presenters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {


        private readonly ICategoriaInputPort _inputPort;

        private readonly ICrearCategoriaOutputPort _crearCategoriaOutputPort;
        private readonly IListarCategoriasOutputPort _listarCategoriaOutputPort;
        private readonly IEliminarCategoriaOutputPort _eliminarCategoriaOutputPort;
        private readonly IEditarCategoriaOutputPort _editarCategoriaOutputPort;
        public CategoriaController(IListarCategoriasOutputPort listarCategoriaOutputPort, 
                                    IEliminarCategoriaOutputPort eliminarCategoriaOutputPort, 
                                    IEditarCategoriaOutputPort editarCategoriaOutputPort,
                                    ICategoriaInputPort inputPort,
                                    ICrearCategoriaOutputPort crearCategoriaOutputPort)
        {
            _inputPort = inputPort;
            _crearCategoriaOutputPort = crearCategoriaOutputPort;
            _listarCategoriaOutputPort = listarCategoriaOutputPort;
            _eliminarCategoriaOutputPort = eliminarCategoriaOutputPort;
            _editarCategoriaOutputPort = editarCategoriaOutputPort;
        }


        [HttpPost("Crear")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaDTO>> CrearCategoria([FromBody] CrearCategoriaDTO modelo)
        {
            try
            {
                await _inputPort.CrearCategoriaHandle(modelo);

                return Ok(((IPresenter<CategoriaDTO>)_crearCategoriaOutputPort).Contenido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("Editar")]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaDTO>> EditarCategoria([FromBody] EditarCategoriaDTO modelo)
        {
            try
            {
                await _inputPort.EditarCategoriaHandle(modelo);

                var seEdito = ((IPresenter<bool>)_editarCategoriaOutputPort).Contenido;

                return Ok(seEdito);
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
        public async Task<ActionResult<CategoriaDTO>> EliminarCategoria(int id)
        {
            try
            {
                await _inputPort.EliminarCategoriaHandle(id);

                var seElimino = ((IPresenter<bool>)_eliminarCategoriaOutputPort).Contenido;

                return seElimino ? Ok($"{seElimino}: Se elimino la categoria correctamente") : NotFound("Categoria no encontrado");
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
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> ListarCategoria()
        {
            try
            {
                await _inputPort.ListarCategoriasHandle();

                var categorias = ((IPresenter<IEnumerable<CategoriaDTO>>)_listarCategoriaOutputPort).Contenido;

                return categorias.Count() > 0 ? Ok(categorias) : NotFound("No se encontro ninguna categoria para listar");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
