namespace ClassLibrary.GamesGuide.Entities
{
    public class AdventureImgEntity
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public int Sort { get; set; }
        public int Id_Adventure { get; set; }
        public AdventureEntity Adventure { get; set; }
    }
}
