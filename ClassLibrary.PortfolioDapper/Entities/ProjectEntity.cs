namespace ClassLibrary.PortfolioDapper.Entities
{
    public class ProjectEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public string RepoUrl { get; set; } = string.Empty;
        public string AppUrl { get; set; } = string.Empty;
    }
}
