using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;
using SistemaPOS.Infrastructure.Persistence;

namespace SistemaPOS.Infrastructure.Data
{
    public class PedidoRepositoryImpl: PedidoRepository
    {
        private readonly ApplicationDbContext _context;

        public PedidoRepositoryImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CerrarPedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if(pedido != null) {
                pedido.Cerrar();
                _context.Entry(pedido).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            throw new Exception("No se encontro el pedido");
        }

        public async Task IngresarPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<Pedido> ModificarPedido(int id, Pedido pedido)
        {
            var pedidoEditar = await _context.Pedidos.FindAsync(id);
            if(pedidoEditar != null)
            {
                //pedidoEditar.Actualizar(pedido.Productos);
                _context.Entry(pedidoEditar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return pedidoEditar;
            }
            throw new Exception("No se encontro el pedido");
        }
    }
}
