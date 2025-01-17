namespace ClassLibrary.GamesGuide.Entities
{
    public class BackgroundImgEntity
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public int Id_Game { get; set; }
        public GameEntity Game { get; set; }
    }
}
