using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Domain.Repositories
{
    public interface PedidoDetalleRepository
    {
        Task GuardarPedidoDetalle(PedidoDetalle pedidoDetalle);
    }
}
