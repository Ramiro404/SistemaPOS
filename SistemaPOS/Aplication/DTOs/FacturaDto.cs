using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Aplication.DTOs
{
    public class FacturaDto
    {
        public Cliente Cliente { get; set; }
        public List<ProductoPedidoAgregarIdsDto> Pedidos { get; set; }
        public Factura Factura { get; set; }
    }
}
