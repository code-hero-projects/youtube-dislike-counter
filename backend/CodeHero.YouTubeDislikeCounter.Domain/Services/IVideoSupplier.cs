using CodeHero.YouTubeDislikeCounter.Domain.Model;

namespace CodeHero.YouTubeDislikeCounter.Domain.Services
{
    public interface IVideoSupplier
    {
        Task<Video> FetchVideo(string id);
    }
}
