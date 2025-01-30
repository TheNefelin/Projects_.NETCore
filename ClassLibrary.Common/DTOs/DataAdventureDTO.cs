namespace ClassLibrary.Common.DTOs
{
    public class DataAdventureDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsImportant { get; set; }
        public int Sort { get; set; }
        public DataAdventureUserDTO AdventureUser { get; set; }
        public ICollection<DataAdventureImgDTO> AdventuresImg { get; set; }
    }
}
