using CodeHero.YouTubeDislikeCounter.Database.Configuration;
using CodeHero.YouTubeDislikeCounter.Database.Mappings;
using CodeHero.YouTubeDislikeCounter.Database.Mappings.CosmosDb;
using CodeHero.YouTubeDislikeCounter.Database.Repositories;
using CodeHero.YouTubeDislikeCounter.Domain.Model;
using CodeHero.YouTubeDislikeCounter.Domain.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeHero.YouTubeDislikeCounter.Database.Extensions
{
    public static class DependenciesRegistration
    {
        public static IServiceCollection AddDatabaseDependencies(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            var databaseOptions = configurationSection.Get<DatabaseConfiguration>();

            switch (databaseOptions.Type)
            {
                case DatabaseType.CosmosDb:
                    AddCosmosDbAsync(services, databaseOptions).Wait();
                    break;
                default:
                    throw new ArgumentException("Database configuration is missing.");
            }

            services
                .AddScoped<IVideoRepository, VideoRepository>()
                .AddSingleton(databaseOptions)
                .AddSingleton<EntitiesConfiguration>();

            return services;
        }

        private static async Task AddCosmosDbAsync(IServiceCollection services, DatabaseConfiguration databaseOptions)
        {
            services
                .AddSingleton<IEntityTypeConfiguration<Video>, CosmosDbVideoMapping>()
                .AddDbContext<DatabaseContext>(dbConfig => dbConfig.UseCosmos(databaseOptions.ConnectionString, databaseOptions.DatabaseName));

            var cosmosClient = new CosmosClient(databaseOptions.ConnectionString);
            var database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseOptions.DatabaseName);

            for (var index = 0; index < databaseOptions.Containers.Length; ++index)
            {
                var container = databaseOptions.Containers[index];
                var partitionKey = databaseOptions.PartitionKeys[index];

                await database.Database.CreateContainerIfNotExistsAsync(container, partitionKey);
            }
        }
    }
}
