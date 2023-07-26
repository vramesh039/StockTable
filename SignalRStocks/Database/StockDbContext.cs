using Microsoft.EntityFrameworkCore;

namespace StockTable
{
    public class StockDbContext : DbContext
    {
        public DbSet<StockUpdate> StockUpdates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=StockDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}