namespace LP022018UP6012019MA603.Models
{
    public class comentario
    {
        public int ComentarioId { get; set; }
        public int PublicacionId { get; set; }
        public int UsuarioId { get; set; }
        public string Comentario { get; set; }
        public Publicaciones Publicacion { get; set; } // propiedad de navegación
        public Usuario Usuario { get; set; } // propiedad de navegación
    }
