using Microsoft.EntityFrameworkCore;
using WebApiMonitores.Entidades;

namespace WebApiMonitores
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { 
        
        }

        public DbSet<Entidades.Monitor> Monitores { get; set; }
    }
}
