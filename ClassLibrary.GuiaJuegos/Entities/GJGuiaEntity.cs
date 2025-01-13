namespace ClassLibrary.GuiaJuegos.Entities
{
    public class GJGuiaEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Orden { get; set; }
        public int Id_Juego { get; set; }
        public ICollection<GJGuiaUsuarioEntity> GJGuiaUsuario { get; set; }
        public ICollection<GJAventuraEntity> GJAventura { get; set; }
    }
}
