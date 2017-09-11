using Microsoft.EntityFrameworkCore;
using YFinder.Models;

namespace YFinder.Data
{
    public class YFinderContext : DbContext
    {
        public YFinderContext(DbContextOptions<YFinderContext> options)
            : base(options)
        { }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");
        }
    }
}
