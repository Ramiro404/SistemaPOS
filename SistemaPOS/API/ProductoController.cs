using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Aplication.Services;

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
            await _productoService.CrearProductoAsync(producto);
            return Created();
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            var productos = await _productoService.ListarProductoAsync();
            return Ok(productos);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Editar(int id, EditarProductoDto producto)
        {
            producto.Id = id;
            await _productoService.EditarProductoAsync(producto);
            return Ok();
        }

        [HttpPatch("ingresarInventario")]
        public async Task<ActionResult> IngresarInventario(IngresarInventarioDto ingresarInventarioDto)
        {
            await _productoService.IngresarInventarioAsync(
                ingresarInventarioDto.ProductoId,
                ingresarInventarioDto.Cantidad);
            return Ok();
        }

        [HttpPatch("descontarInventario")]
        public async Task<ActionResult> DescontarInventario(DescontarInventarioDto descontarInventarioDto)
        {
            await _productoService.DescontarInventarioAsync(
                descontarInventarioDto.ProductoId,
                descontarInventarioDto.Cantidad);
            return Ok();
        }


    }
}
