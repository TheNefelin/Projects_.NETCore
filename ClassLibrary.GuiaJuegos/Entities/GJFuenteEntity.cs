namespace ClassLibrary.GuiaJuegos.Entities
{
    public class GJFuenteEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
        public int Id_Juego { get; set; }
    }
}
