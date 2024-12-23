using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Aplication.Services;
using SistemaPOS.Domain.Entities;

namespace SistemaPOS.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaService _facturaService;

        public FacturaController(FacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpGet()]
        public async Task<IActionResult> ListarFacturados()
        {
            try
            {
                var data = await _facturaService.ListarFacturados();
                return Ok(new Utils.SuccessResult<List<PedidoFacturadoDto>>(data));
            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpGet("Impresion/{id}")]
        public async Task<IActionResult> ObtenerFacturaImpresion(int id)
        {
            try
            {
                var data = await _facturaService.ImprimirFactura(id);
                return Ok(new Utils.SuccessResult<FacturaImpresionDto>(data));
            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpGet("Cliente/{clienteId}")]
        public async Task<IActionResult> ListarFacturasClienteId(int clienteId)
        {
            try
            {
                var data = await _facturaService.ListarFacturasCliente(clienteId);
                return Ok(new Utils.SuccessResult<List<Factura>>(data));

            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }

        [HttpPost("{pedidoId}")]
        public async Task<IActionResult> FacturarPedidos(int pedidoId)
        {
            try
            {
                await _facturaService.FacturarPedido(pedidoId);
                return Ok(new Utils.SuccessResult<dynamic>(null));

            }
            catch (Exception ex)
            {
                return BadRequest(new Utils.BadResult(ex.Message));
            }
        }
    }
}
