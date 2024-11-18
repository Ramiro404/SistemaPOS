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

        [HttpGet("Impresion/{id}")]
        public async Task<FacturaImpresionDto> ObtenerFacturaImpresion(int id)
        {
            return await _facturaService.ImprimirFactura(id);
        }

        [HttpGet("Cliente/{clienteId}")]
        public async Task<List<Factura>> ListarFacturasClienteId(int clienteId)
        {
            return await _facturaService.ListarFacturasCliente(clienteId);
        }

        [HttpPost]
        public async Task FacturarPedidos(List<PedidoDto> pedidos)
        {
            await _facturaService.FacturarPedido(pedidos);
        }
    }
}
