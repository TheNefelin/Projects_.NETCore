namespace ClassLibrary.GamesGuideDapper.Entities
{
    public class GuideEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Sort { get; set; }
        public int Id_Game { get; set; }
    }
}
