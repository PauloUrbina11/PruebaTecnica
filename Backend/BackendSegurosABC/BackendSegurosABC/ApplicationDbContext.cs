using Microsoft.EntityFrameworkCore;

//Configuración de la bd local
namespace BackendSegurosABC
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<SegurosAbc> SegurosAbc { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SegurosAbc>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<SegurosAbc>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
