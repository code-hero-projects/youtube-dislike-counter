namespace CodeHero.YouTubeDislikeCounter.Api.Extensions
{
    public static class DependenciesRegistration
    {
        public static IServiceCollection AddApiDependencies(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(o => o.AddPolicy(ApiConstants.AllowAllCorsPolicy, builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
