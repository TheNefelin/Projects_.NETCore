using ClassLibrary.GamesGuide.Entities;

namespace ClassLibrary.GamesGuide.DTOs
{
    public class DataCharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
    }
}
