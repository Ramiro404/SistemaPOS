namespace SistemaPOS.Utils
{
    public class BadResult: BaseResult
    {

        public BadResult(
            string message = "Error del servidor",
            int status = 500)
        { 
            Status = status;
            Message = message;
        }

    }
}
