using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;
using SistemaPOS.Infrastructure.Persistence;

namespace SistemaPOS.Infrastructure.Data
{
    public class PedidoDetalleRepositoryImpl : PedidoDetalleRepository
    {
        private readonly ApplicationDbContext _context;

        public PedidoDetalleRepositoryImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task GuardarPedidoDetalle(PedidoDetalle pedidoDetalle)
        {
            _context.PedidosDetalle.Add(pedidoDetalle);
            await _context.SaveChangesAsync();
        }
    }
}
