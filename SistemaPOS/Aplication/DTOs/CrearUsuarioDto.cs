namespace SistemaPOS.Aplication.DTOs
{
    public class CrearUsuarioDto
    {
        public string Nombre { get; private set; }
        public string ApellidoPaterno { get; private set; }
        public string ApellidoMaterno { get; private set; }
        public TimeSpan HoraEntrada { get; private set; }
        public TimeSpan HoraSalida { get; private set; }
        public DateTime? FechaInicioSesion { get; private set; }
        public DateTime? FechaCierreSesion { get; private set; }
    }

    public class EditarUsuarioDto: CrearUsuarioDto { }
}
