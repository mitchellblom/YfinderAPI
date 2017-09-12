using Microsoft.EntityFrameworkCore;

using YFinder.Models;

namespace YFinder.Data
{
    public class YFinderContext : DbContext
    {
        public YFinderContext(DbContextOptions<YFinderContext> options)
            : base(options)
        { }

        public DbSet<Descriptor> Descriptor { get; set; }
        public DbSet<Host> Host { get; set; }
        public DbSet<Hotspot> Hotspot { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<RatingDescriptor> RatingDescriptor { get; set; }
        public DbSet<User> User { get; set; }

    }
}
