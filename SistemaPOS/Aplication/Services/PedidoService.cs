using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;

namespace SistemaPOS.Aplication.Services
{
    public class PedidoService
    {
        private readonly PedidoRepository _pedidoRepository;
        private readonly PedidoDetalleRepository _pedidoDetalleRepository;
        private readonly ProductoRepository _productoRepository;

        public PedidoService(
            PedidoRepository pedidoRepository,
            PedidoDetalleRepository pedidoDetalleRepository,
            ProductoRepository productoRepository
            )
        {
            _pedidoRepository = pedidoRepository;
            _pedidoDetalleRepository = pedidoDetalleRepository;
            _productoRepository = productoRepository;
        }

        public async Task IngresarPedidoAsync(CrearPedidoDto crearPedidoDto)
        {
            var pedido = await _pedidoRepository.IngresarPedido(
                new Pedido(crearPedidoDto.ClienteId));

            foreach (var pedidoDetalleDto in crearPedidoDto.Pedidos)
            {
                PedidoDetalle pedidoDetalle = new PedidoDetalle(
                    pedido.Id,
                    pedidoDetalleDto.cantidad,
                    pedidoDetalleDto.ProductoId
                    );
                await _pedidoDetalleRepository.GuardarPedidoDetalle(pedidoDetalle);
                await _productoRepository.DescontarInventario(pedidoDetalle.ProductoId, pedidoDetalle.Cantidad);
            }
        }

        public async Task<PedidoDto> ModificarPedidoDto()
        {
            throw new NotImplementedException();

        }

        public async Task CerrarPedidoAsync(int id)
        {
            await _pedidoRepository.CerrarPedido(id);
        }

        public async Task<List<PedidoPendienteDto>> ListarPedidosPendientesAsync()
        {
           return await _pedidoRepository.ListarPedidosPendientes();
        }

        public async Task<List<PedidoFacturadoDto>> ListarPedidoFacturadosAsync()
        {
            return await _pedidoRepository.PedidosFacturados();
        }

    }
}
