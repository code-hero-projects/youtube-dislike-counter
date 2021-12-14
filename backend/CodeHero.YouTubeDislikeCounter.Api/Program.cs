using CodeHero.YouTubeDislikeCounter.Api;
using CodeHero.YouTubeDislikeCounter.Api.Extensions;
using CodeHero.YouTubeDislikeCounter.Application.Extensions;
using CodeHero.YouTubeDislikeCounter.Database.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

var databaseConfiguration = configuration.GetSection(ApiConstants.AppSettingsDatabaseSection);
var youTubeConfiguration = configuration.GetSection(ApiConstants.AppSettingsYouTubeSection);

// Add services to the container.
services.AddDatabaseDependencies(databaseConfiguration);
services.AddApplicationDependencies(youTubeConfiguration);
services.AddApiDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
