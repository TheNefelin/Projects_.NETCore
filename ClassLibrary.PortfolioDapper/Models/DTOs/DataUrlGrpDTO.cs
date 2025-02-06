namespace ClassLibrary.PortfolioDapper.Models.DTOs
{
    public class DataUrlGrpDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsEnable { get; set; }
        public ICollection<DataUrlDTO> Urls { get; set; }
    }
}
