namespace ClassLibrary.GamesGuide.DTOs
{
    public class DataGameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public ICollection<DataCharacterDTO> Characters { get; set; }
        public ICollection<DataSourceDTO> Sources { get; set; }
        public ICollection<DataBackgroundDTO> Backgrounds { get; set; }
        public ICollection<DataGuideDTO> Guides { get; set; }
    }
}
