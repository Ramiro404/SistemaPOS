namespace SistemaPOS.Aplication.DTOs
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal ValorUnitario { get; set; }
        public float Medida { get; set; }
        public string UnidadMedida { get; set; }
        public float Peso { get; set; }
        public float VolumenEmpaque { get; set; }
    }

    public class ProductoCantidadDto
    {
        public ProductoDto producto { get; set; }
        public int cantidad { get; set; }
    }
}
