using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Domain.Repositories
{
    public interface FacturaRepository
    {
        Task FacturarPedido(List<Pedido> pedidos);
        Task<string> ImprimirFactura(int facturaId);
        Task<List<Factura>> ListarFacturaDeCliente(int clienteId);
    }
}
