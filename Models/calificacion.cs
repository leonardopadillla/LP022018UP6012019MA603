namespace LP022018UP6012019MA603.Models
{
    public class calificacion
    {
        public int CalificacionId { get; set; }
        public int PublicacionId { get; set; }
        public int UsuarioId { get; set; }
        public int Calificacion { get; set; }
        public publicacion Publicacion { get; set; }
        public usuario Usuario { get; set; }
    }
}

