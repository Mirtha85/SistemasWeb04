using Microsoft.EntityFrameworkCore;

namespace SistemasWeb01.Models
{
    public class BethesdaPieShopDbContext : DbContext
    {
        public BethesdaPieShopDbContext(DbContextOptions<BethesdaPieShopDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }
    }
}