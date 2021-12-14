using CodeHero.YouTubeDislikeCounter.Application.Configuration;
using CodeHero.YouTubeDislikeCounter.Application.Services;
using CodeHero.YouTubeDislikeCounter.Domain.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CodeHero.YouTubeDislikeCounter.Application.Extensions
{
    public static class DependenciesRegistration
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfigurationSection youTubeConfiguration)
        {
            var youTubeOptions = youTubeConfiguration.Get<YouTubeConfiguration>();

            services.AddSingleton(youTubeOptions);
            services.AddScoped<IVideoSupplier, YouTubeVideoSupplier>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
