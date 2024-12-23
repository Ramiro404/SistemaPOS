using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Domain.Repositories
{
    public interface PedidoRepository
    {
        public Task<Pedido> IngresarPedido(Pedido pedido);
        public Task<Pedido> ModificarPedido(int id, Pedido pedido);
        public Task CerrarPedido(int id);
        Task<List<PedidoPendienteDto>> ListarPedidosPendientes();
        Task<List<PedidoFacturadoDto>> PedidosFacturados();
    }
}
