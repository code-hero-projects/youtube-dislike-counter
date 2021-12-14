#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CodeHero.YouTubeDislikeCounter.Api/CodeHero.YouTubeDislikeCounter.Api.csproj", "CodeHero.YouTubeDislikeCounter.Api/"]
COPY ["CodeHero.YouTubeDislikeCounter.Application/CodeHero.YouTubeDislikeCounter.Application.csproj", "CodeHero.YouTubeDislikeCounter.Application/"]
COPY ["CodeHero.YouTubeDislikeCounter.Domain/CodeHero.YouTubeDislikeCounter.Domain.csproj", "CodeHero.YouTubeDislikeCounter.Domain/"]
COPY ["CodeHero.YouTubeDislikeCounter.Database/CodeHero.YouTubeDislikeCounter.Database.csproj", "CodeHero.YouTubeDislikeCounter.Database/"]
RUN dotnet restore "CodeHero.YouTubeDislikeCounter.Api/CodeHero.YouTubeDislikeCounter.Api.csproj"
COPY . .
WORKDIR "/src/CodeHero.YouTubeDislikeCounter.Api"
RUN dotnet build "CodeHero.YouTubeDislikeCounter.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CodeHero.YouTubeDislikeCounter.Api.csproj" -c Release -o /app/publish

FROM base AS final
ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "CodeHero.YouTubeDislikeCounter.Api.dll"]