namespace ClassLibrary.PortfolioDapper.Models.DTOs
{
    public class DataProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public string RepoUrl { get; set; } = string.Empty;
        public string AppUrl { get; set; } = string.Empty;
        public ICollection<DataLanguageDTO> Languages { get; set; }
        public ICollection<DataTechnologyDTO> Technologies { get; set; }
    }
}
