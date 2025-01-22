namespace ClassLibrary.GamesGuide.Entities
{
    public class AdventureEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsImportant { get; set; }
        public int Sort { get; set; }
        public int Id_Guide { get; set; }
        public GuideEntity Guide { get; set; }
        public ICollection<AdventureImgEntity> AdventuresImg { get; set; }
        public ICollection<AdventureUserEntity> AdventuresUser { get; set; }
    }
}
