using Microsoft.EntityFrameworkCore;
using RunnerApi.Models;

namespace RunnerApi.Data
{
    public class RunnersDbContext : DbContext
    {
        public RunnersDbContext(DbContextOptions<RunnersDbContext> options)
            : base(options) { }

        public DbSet<Runner> Runners { get; set; }
        public DbSet<GrupoSocial> GruposSociales { get; set; }
        public DbSet<Clasificacion> Clasificaciones { get; set; }
        public DbSet<Recorrido> Recorridos { get; set; }
        public DbSet<Ventaja> Ventajas { get; set; }

    }
}
