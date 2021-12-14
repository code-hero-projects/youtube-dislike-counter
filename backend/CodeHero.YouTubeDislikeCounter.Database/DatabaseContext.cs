using CodeHero.YouTubeDislikeCounter.Database.Mappings;
using CodeHero.YouTubeDislikeCounter.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeHero.YouTubeDislikeCounter.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        private readonly EntitiesConfiguration _entitiesConfiguration;

        public DatabaseContext(EntitiesConfiguration entitiesConfiguration, DbContextOptions options) : base(options) => _entitiesConfiguration = entitiesConfiguration;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _entitiesConfiguration.ApplyConfiguration(modelBuilder);
        }
    }
}
