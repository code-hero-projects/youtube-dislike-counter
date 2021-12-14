using CodeHero.YouTubeDislikeCounter.Domain.Repositories;
using CodeHero.YouTubeDislikeCounter.Domain.Services;
using MediatR;

namespace CodeHero.YouTubeDislikeCounter.Application.Commands.GetVideo
{
    public class GetVideoHandler : IRequestHandler<GetVideoRequest, GetVideoResponse>
    {
        private readonly IVideoSupplier _videoSupplier;
        private readonly IVideoRepository _videoRepository;

        public GetVideoHandler(IVideoSupplier videoSupplier, IVideoRepository videoRepository)
        {
            _videoSupplier = videoSupplier;
            _videoRepository = videoRepository;
        }

        public async Task<GetVideoResponse> Handle(GetVideoRequest request, CancellationToken cancellationToken)
        {
            var video = await _videoRepository.GetAsync(video => video.Id == request.Id);

            if (video == null)
            {
                video = await _videoSupplier.FetchVideo(request.Id);
                await _videoRepository.AddAsync(video);
                await _videoRepository.SaveChangesAsync();
            }

            return new GetVideoResponse()
            {
                Id = video.Id,
                Dislikes = video.Dislikes
            };
        }
    }
}
