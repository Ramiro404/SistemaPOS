using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Domain.Repositories
{
    public interface PedidoRepository
    {
        public Task IngresarPedido(Pedido pedido);
        public Task<Pedido> ModificarPedido(int id, Pedido pedido);
        public Task CerrarPedido(int id);
    }
}
