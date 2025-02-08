namespace ClassLibrary.GamesGuideDapper.DTOs
{
    public class AdventureDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsImportant { get; set; }
        public int Sort { get; set; }
        public int Id_Guide { get; set; }
    }
}
