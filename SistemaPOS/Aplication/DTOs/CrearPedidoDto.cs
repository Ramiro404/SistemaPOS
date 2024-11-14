using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Aplication.DTOs
{
    public class CrearPedidoDto
    {
        public int ClienteId { get; set; }
        public List<ProductoCantidadDto> Productos { get; set; }
    }


    public class EditarPedidoDto: CrearPedidoDto { }
}
