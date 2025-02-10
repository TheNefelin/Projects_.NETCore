namespace ClassLibrary.F1Dapper.DTOs
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImgCar { get; set; } = string.Empty;
        public FlagDTO flag { get; set; }
        public ICollection<PilotDTO> pilots { get; set; }
    }
}
