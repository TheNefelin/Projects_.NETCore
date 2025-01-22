namespace ClassLibrary.GamesGuide.Entities
{
    public class GuideUserEntity
    {
        public int Id_Guide { get; set; }
        public string Id_User { get; set; } = string.Empty;
        public bool IsCheck { get; set; }
        public GuideEntity Guide { get; set; }
    }
}
