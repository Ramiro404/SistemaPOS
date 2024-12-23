using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Domain.Repositories
{
    public interface FacturaRepository
    {
        Task FacturarPedido(List<Pedido> pedidos);
        Task FacturarPedido(int pedidoId);
        Task<string> ImprimirFactura(int facturaId);
        Task<List<Factura>> ListarFacturaDeCliente(int clienteId);
        Task<List<PedidoFacturadoDto>> ListarFacturas();

    }
}
