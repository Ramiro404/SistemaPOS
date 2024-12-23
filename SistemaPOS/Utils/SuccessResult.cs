namespace SistemaPOS.Utils
{
    public class SuccessResult<T>: BaseResult
    {
        public T? Data { get; set; }

        public SuccessResult(
            T data,
            int status = 200,
            string message = "Success") { 
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
