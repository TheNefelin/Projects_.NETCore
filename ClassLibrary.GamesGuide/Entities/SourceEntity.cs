namespace ClassLibrary.GamesGuide.Entities
{
    public class SourceEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public int Id_Game { get; set; }
        public GameEntity Game { get; set; }
    }
}
