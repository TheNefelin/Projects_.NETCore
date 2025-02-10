namespace ClassLibrary.F1Dapper.DTOs
{
    public class PilotDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateBirth { get; set; }
        public decimal Height { get; set; }
        public int Weight { get; set; }
        public int Dorsal { get; set; }
        public string ImgProfile { get; set; } = string.Empty;
        public bool IsAlive { get; set; }
        public int Points { get; set; }
        public FlagDTO flag { get; set; }
        public TeamDTO team { get; set; }
    }
}
