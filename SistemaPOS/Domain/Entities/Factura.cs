namespace SistemaPOS.Domain.Entities
{
    public class Factura
    {
        public int Id { get; private set; }
        public string Folio { get; private set; }
        public int PedidoId { get; private set; }
        public Decimal ValorTotal { get; private set; }
        public Decimal ValorImpuestos { get; private set; }
        public Decimal ValorDescuento { get; private set; }
        public DateTime FechaCreacion { get; private set; }

        public Factura(string folio, int pedidoId, decimal valorTotal, decimal valorImpuestos, decimal valorDescuento, DateTime fechaCreacion)
        {
            Folio = folio;
            PedidoId = pedidoId;
            ValorTotal = valorTotal;
            ValorImpuestos = valorImpuestos;
            ValorDescuento = valorDescuento;
            FechaCreacion = DateTime.Now;
        }
    }
}
