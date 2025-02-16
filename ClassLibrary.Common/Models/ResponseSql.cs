namespace ClassLibrary.Common.Models
{
    public class ResponseSql
    {
        public required bool IsSucces { get; set; }
        public required int StatusCode { get; set; }
        public required string Msge { get; set; }
    }
}
