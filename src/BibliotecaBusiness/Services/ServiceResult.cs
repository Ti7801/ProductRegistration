namespace BibliotecaBusiness.Services
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public ServiceResult(bool sucess, string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.Success = sucess;
        }
    }
}
