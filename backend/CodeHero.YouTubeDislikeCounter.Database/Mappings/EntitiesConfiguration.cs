using CodeHero.YouTubeDislikeCounter.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeHero.YouTubeDislikeCounter.Database.Mappings
{
    public class EntitiesConfiguration
    {
        private readonly IEntityTypeConfiguration<Video> _videoConfiguration;

        public EntitiesConfiguration(IEntityTypeConfiguration<Video> videoConfiguration) => _videoConfiguration = videoConfiguration;

        public void ApplyConfiguration(ModelBuilder modelBuilder) => modelBuilder.ApplyConfiguration(_videoConfiguration);
    }
}
