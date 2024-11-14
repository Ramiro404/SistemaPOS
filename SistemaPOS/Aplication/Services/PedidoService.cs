using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;

namespace SistemaPOS.Aplication.Services
{
    public class PedidoService
    {
        private readonly PedidoRepository _pedidoRepository;

        public PedidoService(PedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task IngresarPedidoAsync(CrearPedidoDto crearPedidoDto)
        {
            foreach(var producto in crearPedidoDto.Productos)
            {
                Pedido pedido = new Pedido(
                    crearPedidoDto.ClienteId,
                    producto.producto.Id,
                    producto.cantidad);
                await _pedidoRepository.IngresarPedido(pedido);
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


    }
}
