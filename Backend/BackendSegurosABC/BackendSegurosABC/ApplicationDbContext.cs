using Microsoft.EntityFrameworkCore;

namespace BackendSegurosABC
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<SegurosAbc> SegurosAbc { get; set; }
    }
}
