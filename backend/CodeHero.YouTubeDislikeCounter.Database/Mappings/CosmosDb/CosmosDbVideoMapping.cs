using CodeHero.YouTubeDislikeCounter.Database.Configuration;
using CodeHero.YouTubeDislikeCounter.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeHero.YouTubeDislikeCounter.Database.Mappings.CosmosDb
{
    public class CosmosDbVideoMapping : IEntityTypeConfiguration<Video>
    {
        public readonly DatabaseConfiguration _databaseConfiguration;

        public CosmosDbVideoMapping(DatabaseConfiguration databaseConfiguration) => _databaseConfiguration = databaseConfiguration;

        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Dislikes)
                .IsRequired();

            builder.HasPartitionKey(x => x.Id);

            builder.ToContainer(_databaseConfiguration.Containers[0]);
        }
    }
}
