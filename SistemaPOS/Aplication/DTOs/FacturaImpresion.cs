using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Aplication.DTOs
{
    public class FacturaImpresion
    {
        public Factura factura {  get; set; }
        public Cliente cliente { get; set; }
        public Pedido pedido { get; set; }
        public Producto producto { get; set; }
    }
}
