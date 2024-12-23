using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Aplication.Services;
using SistemaPOS.Domain.Entities;

namespace SistemaPOS.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService  _productoService;

        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpPost]
        public async Task<ActionResult> Crear(CrearProductoDto producto)
        {
            try
            {
                await _productoService.CrearProductoAsync(producto);
                return Ok(new Utils.SuccessResult<dynamic>(null));
            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerPorId(int id)
        {
            try
            {
                var productos = await _productoService.ObtenerPorIdAsync(id);
                return Ok(new Utils.SuccessResult<ProductoDto>(productos));
            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var productos = await _productoService.ListarProductoAsync();
                return Ok(new Utils.SuccessResult<List<ProductoDto>>(productos));
            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Editar(int id, EditarProductoDto producto)
        {

            try
            {
                await _productoService.EditarProductoAsync(id, producto);
                return Ok(new Utils.SuccessResult<dynamic>(null));
            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }

        }

        [HttpPatch("ingresarInventario")]
        public async Task<ActionResult> IngresarInventario(IngresarInventarioDto ingresarInventarioDto)
        {
            try
            {
                await _productoService.IngresarInventarioAsync(
                ingresarInventarioDto.ProductoId,
                ingresarInventarioDto.Cantidad);
                return Ok(new Utils.SuccessResult<dynamic>(null));
            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpPatch("descontarInventario")]
        public async Task<ActionResult> DescontarInventario(DescontarInventarioDto descontarInventarioDto)
        {
            try
            {
                await _productoService.DescontarInventarioAsync(
                descontarInventarioDto.ProductoId,
                descontarInventarioDto.Cantidad);
                return Ok(new Utils.SuccessResult<dynamic>(null));

            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                await _productoService.EliminarProductoAsync(id);
                return Ok(new Utils.SuccessResult<dynamic>(null));
            }
            catch(Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }


    }
}
