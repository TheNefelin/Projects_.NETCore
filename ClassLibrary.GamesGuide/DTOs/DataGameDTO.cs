namespace ClassLibrary.GamesGuide.DTOs
{
    public class DataGameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public int Id_Game { get; set; }
        public ICollection<DataCharacterDTO> Characters { get; set; }
        public ICollection<DataSourceDTO> Sources { get; set; }
        public ICollection<DataBackgroundImgDTO> BackgroundImg { get; set; }
    }
}
