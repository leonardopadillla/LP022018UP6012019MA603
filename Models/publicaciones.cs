namespace LP022018UP6012019MA603.Models
{
    public class Publicaciones
    {
        public int PublicacionId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } // propiedad de navegación
        public List<comentario> Comentarios { get; set; } // propiedad de navegación
        public List<Calificaciones> Calificaciones { get; set; } // propiedad de navegación
    }