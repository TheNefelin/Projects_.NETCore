namespace ClassLibrary.PortfolioDapper.DTOs
{
    public class DataUrlDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public bool IsEnable { get; set; }
    }
}
