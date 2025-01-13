namespace ClassLibrary.GuiaJuegos.Entities
{
    public class GJJuegoEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public bool Activo { get; set; }
        //public ICollection<GJPersonajeEntity> GJPersonajes { get; set; }
        //public ICollection<GJFuenteEntity> GJFuentes { get; set; }
        //public ICollection<GJFondoImgEntity> GJFondosImg { get; set; }
        //public ICollection<GJGuiaEntity> GJGuias { get; set; }
    }
}
