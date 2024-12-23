using Microsoft.EntityFrameworkCore;
using SistemaPOS.Aplication.DTOs;
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

        public async Task<List<PedidoPendienteDto>> ListarPedidosPendientes()
        {
            var pedidosPendientes = await _context.Pedidos
                    .Where(p => p.FechaCierre == null)
                    .ToListAsync();
            var pedidosPendientesDto = new List<PedidoPendienteDto>();
            foreach(var pedido in pedidosPendientes)
            {
                var cliente = await _context.Clientes.FindAsync(pedido.ClienteId);
                pedidosPendientesDto.Add(new PedidoPendienteDto
                {
                    ClienteId = cliente.Id,
                    NumeroDocumento = cliente.NumeroDocumento,
                    Unidades = 0
                });
            }
            return pedidosPendientesDto;
        }

        public async Task CerrarPedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if(pedido != null) {
                EsPedidoCerrado(pedido.FechaCierre);
                pedido.Cerrar();
                _context.Entry(pedido).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            throw new Exception("No se encontro el pedido");
        }

        public async Task<Pedido> IngresarPedido(Pedido pedido)
        {
            var clienteExiste = _context.Clientes.FirstOrDefault(c => c.Id == pedido.ClienteId);
            if(clienteExiste == null) {
                throw new Exception("El cliente no existe");
            }

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task<Pedido> ModificarPedido(int id, Pedido pedido)
        {
            var pedidoEditar = await _context.Pedidos.FindAsync(id);
            if(pedidoEditar != null)
            {
                EsPedidoCerrado(pedido.FechaCierre);
                EsPedidoEliminado(pedido.Eliminado);
                _context.Entry(pedidoEditar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return pedidoEditar;
            }
            throw new Exception("No se encontro el pedido");
        }

        public async Task EliminarPedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                EsPedidoEliminado(pedido.Eliminado);
                EsPedidoCerrado(pedido.FechaCierre);
                pedido.Eliminar();
                _context.Entry(pedido).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        private void EsPedidoCerrado(DateTime? cerrado)
        {
            if(cerrado !=  null)
            {
                throw new Exception("El pedido ya esta cerrado");
            }
        }
        private void EsPedidoEliminado(bool eliminado)
        {
            if(eliminado)
            {
                throw new Exception("El pedido ya esta eliminado");
            }
        }

        public async Task<List<PedidoFacturadoDto>> PedidosFacturados()
        {
            return await (
                from pf in _context.Pedidos 
                join cl in _context.Clientes on pf.ClienteId equals cl.Id
                where pf.FacturaId != null
                select new PedidoFacturadoDto
                {
                    Id= pf.Id,
                    FechaFacturacion= pf.FechaFacturacion ?? new DateTime(),
                    NumeroDocumento= cl.NumeroDocumento,
                }).ToListAsync();
        }
    }
}
