namespace inoa.code_challenge.console.Model.DTO.Message
{
    public class BaseResponse<T> where T : class
    {
        public bool Situation { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }                  
    }
}