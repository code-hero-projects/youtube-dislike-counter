using CodeHero.YouTubeDislikeCounter.Domain.Model;
using CodeHero.YouTubeDislikeCounter.Domain.Repositories;

namespace CodeHero.YouTubeDislikeCounter.Database.Repositories
{
    public class VideoRepository : BaseRepository<Video>, IVideoRepository
    {
        public VideoRepository(DatabaseContext databaseContext) : base(databaseContext.Videos, databaseContext)
        {
        }
    }
}
