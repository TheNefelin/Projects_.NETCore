namespace ClassLibrary.GamesGuide.Entities
{
    public class GameEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public bool IdActive { get; set; }
        public ICollection<CharacterEntity> Characters { get; set; }
        public ICollection<SourceEntity> Source { get; set; }
        public ICollection<BackgroundEntity> Backgrounds { get; set; }
        public ICollection<GuideEntity> Guides { get; set; }
    }
}
