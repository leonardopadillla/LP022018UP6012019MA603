using LP022018UP6012019MA603.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using LP022018UP6012019MA603.Models;

namespace LP022018UP6012019MA603

{
    public class blogdbContext : DbContext 
    {
        public blogdbContext(DbContextOptions<blogdbContext> options) : base(options)
        {
        }

        public DbSet<Calificaciones> calificaciones {get; set;}
        public DbSet<Comentarios> estados_equipo {get; set;}
        public DbSet<Publicaciones> publicaciones {get; set;}
        public DbSet<Usuario> usuarios {get; set;}
        public DbSet<Roles> roles{get; set;}
    }
}