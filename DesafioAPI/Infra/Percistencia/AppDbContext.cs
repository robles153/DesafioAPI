using DesafioAPI.Dominio.Entidades.Usuario;
using Microsoft.EntityFrameworkCore;

namespace DesafioAPI.Infra.Percistencia
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            base.OnModelCreating(modelBuilder);
        }
    }
}
