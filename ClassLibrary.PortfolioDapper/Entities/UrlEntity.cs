namespace ClassLibrary.PortfolioDapper.Entities
{
    public class UrlEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public bool IsEnable { get; set; }
        public int Id_UrlGrp { get; set; }
    }
}
