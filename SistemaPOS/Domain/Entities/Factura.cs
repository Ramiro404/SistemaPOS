namespace SistemaPOS.Domain.Entities
{
    public class Factura
    {
        public int Id { get; private set; }
        public string Folio { get; private set; }
        public Decimal ValorTotal { get; private set; }
        public Decimal ValorImpuestos { get; private set; }
        public Decimal ValorDescuento { get; private set; }
        public DateTime FechaCreacion { get; private set; }

        public Factura(string folio, decimal valorTotal, decimal valorImpuestos, decimal valorDescuento)
        {
            Folio = folio;
            ValorTotal = valorTotal;
            ValorImpuestos = valorImpuestos;
            ValorDescuento = valorDescuento;
            FechaCreacion = DateTime.Now;
        }

        public Factura(int id, string folio, decimal valorTotal, decimal valorImpuestos, decimal valorDescuento, DateTime fechaCreacion)
        {
            Id = id;
            Folio = folio;
            ValorTotal = valorTotal;
            ValorImpuestos = valorImpuestos;
            ValorDescuento = valorDescuento;
            FechaCreacion = fechaCreacion;
        }
    }
}
