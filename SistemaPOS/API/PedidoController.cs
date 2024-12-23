using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Aplication.Services;
using SistemaPOS.Domain.Entities;

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
            try
            {
                await _pedidoService.IngresarPedidoAsync(pedido);
                return CreatedAtAction(
                    nameof(Ingresar),
                    new Utils.SuccessResult<dynamic>(null));
            }
            catch(Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpPatch("Cerrar")]
        public async Task<ActionResult> Cerrar(int id)
        {
            try
            {
                await _pedidoService.CerrarPedidoAsync(id);
                return Ok(new Utils.SuccessResult<dynamic>(null));
            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpGet("Pendientes")]
        public async Task<ActionResult> ListarPendientes()
        {
            try
            {
                var data = await _pedidoService.ListarPedidosPendientesAsync();
                return Ok(new Utils.SuccessResult<List<PedidoPendienteDto>>(data));
            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpGet("Facturados")]
        public async Task<ActionResult> ListarFacturados()
        {
            try
            {
                var data = await _pedidoService.ListarPedidoFacturadosAsync();
                return Ok(new Utils.SuccessResult<List<PedidoFacturadoDto>>(data));
            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }
    }
}
