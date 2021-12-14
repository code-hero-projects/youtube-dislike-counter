using CodeHero.YouTubeDislikeCounter.Domain.Repositories;
using MediatR;

namespace CodeHero.YouTubeDislikeCounter.Application.Commands.UpdateDislikes
{
    public class UpdateDislikesHandler : IRequestHandler<UpdateDislikesRequest, UpdateDislikesResponse>
    {
        private readonly IVideoRepository _videoRepository;

        public UpdateDislikesHandler(IVideoRepository videoRepository) => _videoRepository = videoRepository;

        public async Task<UpdateDislikesResponse> Handle(UpdateDislikesRequest request, CancellationToken cancellationToken)
        {
            var video = await _videoRepository.GetAsync(video => video.Id == request.VideoId);

            if (video != null)
            {
                video.Dislikes += request.IsDislike ? 1 : -1;
                _videoRepository.Update(video);
                await _videoRepository.SaveChangesAsync();
            }

            return new UpdateDislikesResponse()
            {
                Message = "Updated"
            };
        }
    }
}
