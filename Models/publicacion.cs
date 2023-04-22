namespace LP022018UP6012019MA603.Models
{
    public class publicacion
    {
        public int PublicacionId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }
        public usuario Usuario { get; set; }
        public List<comentario> Comentario { get; set; }
        public List<calificacion> Calificacion { get; set; }
    }
}