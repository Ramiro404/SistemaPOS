namespace SistemaPOS.Domain.Entities
{
    public class PedidoDetalle
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int Cantidad { get; private set; }
        public int ProductoId { get; private set; }

        public PedidoDetalle(int pedidoId, int cantidad, int productoId)
        {
            PedidoId = pedidoId;
            Cantidad = cantidad;
            ProductoId = productoId;
        }
    }

}
