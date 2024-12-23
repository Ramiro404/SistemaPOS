using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;

namespace SistemaPOS.Aplication.Services
{
    public class FacturaService
    {
        private readonly FacturaRepository _facturaRepository;

        public FacturaService(FacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public async Task<FacturaImpresionDto> ImprimirFactura(int facturaId)
        {
            var factura = await _facturaRepository.ImprimirFactura(facturaId);
            return new FacturaImpresionDto { facturaBase64 = factura };
        }

        public async Task<List<Factura>> ListarFacturasCliente(int clienteId)
        {
            return await _facturaRepository.ListarFacturaDeCliente(clienteId);
        }

        public async Task FacturarPedido(int pedidoId)
        {
            await _facturaRepository.FacturarPedido(pedidoId);
        }

        public async Task<List<PedidoFacturadoDto>> ListarFacturados()
        {
            return await _facturaRepository.ListarFacturas();
        }
    }
}
