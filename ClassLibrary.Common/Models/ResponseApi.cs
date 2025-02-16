namespace ClassLibrary.Common.Models
{
    public class ResponseApi<T>
    {
        public required bool IsSucces { get; set; }
        public required int StatusCode { get; set; }
        public required string Message { get; set; }
        public T? Data { get; set; }
    }
}
