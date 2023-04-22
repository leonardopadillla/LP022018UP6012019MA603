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

        public DbSet<calificacion> calificacion {get; set;}
        public DbSet<comentario> estados_equipo {get; set;}
        public DbSet<publicacion> publicacion {get; set;}
        public DbSet<usuario> usuario {get; set;}
        public DbSet<rol> rol{get; set;}
    }
}