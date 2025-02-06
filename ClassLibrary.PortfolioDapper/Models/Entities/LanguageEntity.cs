namespace ClassLibrary.PortfolioDapper.Models.Entities
{
    public class LanguageEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public int Id_Project { get; set; }
    }
}
