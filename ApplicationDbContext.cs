using Microsoft.EntityFrameworkCore;
using WebApiMonitores.Entidades;

namespace WebApiMonitores
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { 
        
        }

        public DbSet<Entidades.Monitor> Monitores { get; set; }
        public DbSet<Provedor> Provedores { get; set; }

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provedor>()
                .HasMany(m => m.Monitores)
                .WithOne(p => p.Provedor)
                .HasForeignKey(p => p.ProvedorId);

        }*/
    }
}
