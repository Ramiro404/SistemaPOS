namespace SistemaPOS.Domain.Entities
{
    public class PedidoFactura
    {
        public int PedidoId { get; private set; }
        public int FacturaId { get; private set; }

        public PedidoFactura(int pedidoId, int facturaId)
        {
            PedidoId = pedidoId;
            FacturaId = facturaId;
        }
    }
}
