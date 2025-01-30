namespace ClassLibrary.Common.DTOs
{
    public class DataGuideDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Sort { get; set; }
        public DataGuideUserDTO GuideUser { get; set; }
        public ICollection<DataAdventureDTO> Adventures { get; set; }
    }
}
