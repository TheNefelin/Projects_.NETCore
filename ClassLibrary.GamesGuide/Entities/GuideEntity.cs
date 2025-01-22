namespace ClassLibrary.GamesGuide.Entities
{
    public class GuideEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Sort { get; set; }
        public int Id_Game { get; set; }
        public GameEntity Game { get; set; }
        public ICollection<AdventureEntity> Adventures { get; set; }
        public ICollection<GuideUserEntity> GuidesUser { get; set; }
    }
}