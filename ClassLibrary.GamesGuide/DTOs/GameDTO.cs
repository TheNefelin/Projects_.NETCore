namespace ClassLibrary.GamesGuide.DTOs
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public bool IdActive { get; set; }
    }
}
