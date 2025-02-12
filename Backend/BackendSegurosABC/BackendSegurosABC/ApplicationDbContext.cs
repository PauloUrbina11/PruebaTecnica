using Microsoft.EntityFrameworkCore;

//Configuración de la bd local
namespace BackendSegurosABC
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<SegurosAbc> SegurosAbc { get; set; }
    }
}
