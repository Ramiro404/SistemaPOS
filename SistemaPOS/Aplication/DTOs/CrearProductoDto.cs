namespace SistemaPOS.Aplication.DTOs
{
    public class CrearProductoDto
    {
        public string Nombre { get; set; }
        public decimal ValorUnitario { get; set; }
        public float Medida { get; set; }
        public string UnidadMedida { get; set; }
        public float Peso { get; set; }
        public float VolumenEmpaque { get; set; }
        public int Stock {  get; set; }
    }

    public class EditarProductoDto: CrearProductoDto {


    }
}
