namespace LP022018UP6012019MA603.Models
{
    public class Calificaciones
    {
        public int CalificacionId { get; set; }
        public int PublicacionId { get; set; }
        public int UsuarioId { get; set; }
        public int Calificacion { get; set; }
        public Publicaciones Publicacion { get; set; } 
        public Usuario Usuario { get; set; } 
    }

