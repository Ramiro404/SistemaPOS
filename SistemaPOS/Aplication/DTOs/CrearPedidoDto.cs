using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Aplication.DTOs
{
    public class CrearPedidoDto
    {
        public int ClienteId { get; set; }
        public List<ProductoPedidoAgregarIdsDto> Pedidos { get; set; }
        //public List<ProductoCantidadDto> Productos { get; set; }
    }

    public class ProductoPedidoAgregarIdsDto
    {
        public int ProductoId { get; set; }
        public int cantidad { get; set; }
    }


    public class EditarPedidoDto: CrearPedidoDto { }
}
