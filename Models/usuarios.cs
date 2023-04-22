namespace LP022018UP6012019MA603.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Roles Rol { get; set; } // propiedad de navegación
    }

}