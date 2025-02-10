namespace ClassLibrary.F1Dapper.DTOs
{
    public class CircuitDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public FlagDTO Flag { get; set; }
    }
}
