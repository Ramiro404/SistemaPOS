using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Aplication.Services;

namespace SistemaPOS.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<ActionResult> Ingresar(CrearPedidoDto pedido)
        {
            await _pedidoService.IngresarPedidoAsync(pedido);
            return Created();
        }

        [HttpPatch]
        public async Task<ActionResult> Cerrar(int id)
        {
            await _pedidoService.CerrarPedidoAsync(id);
            return Ok();
        }
    }
}
