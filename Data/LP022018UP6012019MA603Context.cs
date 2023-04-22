using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LP022018UP6012019MA603.Models;

namespace LP022018UP6012019MA603.Data
{
    public class LP022018UP6012019MA603Context : DbContext
    {
        public LP022018UP6012019MA603Context (DbContextOptions<LP022018UP6012019MA603Context> options)
            : base(options)
        {
        }

        public DbSet<LP022018UP6012019MA603.Models.calificacion> calificacion { get; set; } = default!;

        public DbSet<LP022018UP6012019MA603.Models.usuario>? usuario { get; set; }

        public DbSet<LP022018UP6012019MA603.Models.comentario>? comentario { get; set; }

        public DbSet<LP022018UP6012019MA603.Models.publicacion>? publicacion { get; set; }

        public DbSet<LP022018UP6012019MA603.Models.rol>? rol { get; set; }
    }
}
