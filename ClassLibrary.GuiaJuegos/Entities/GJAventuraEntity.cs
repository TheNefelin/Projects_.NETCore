namespace ClassLibrary.GuiaJuegos.Entities
{
    public class GJAventuraEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Importante { get; set; }
        public int Orden { get; set; }
        public int Id_Guia { get; set; }
    }
}
