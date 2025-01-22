namespace ClassLibrary.GamesGuide.Entities
{
    public class AdventureUserEntity
    {
        public int Id_Adventure { get; set; }
        public string Id_User { get; set; } = string.Empty;
        public bool IsCheck { get; set; }
        public AdventureEntity Adventure { get; set; }
    }
}
