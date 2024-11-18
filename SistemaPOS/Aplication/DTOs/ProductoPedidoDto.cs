using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Aplication.DTOs
{
    public class ProductoPedidoDto
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
