namespace ClassLibrary.F1Dapper.Entities
{
    public class PilotEntity
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
        public int Id_Flag { get; set; }
        public int Id_Team {  get; set; }
    }
}
