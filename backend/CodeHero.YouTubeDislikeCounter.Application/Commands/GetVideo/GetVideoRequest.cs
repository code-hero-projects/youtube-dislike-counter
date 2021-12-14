using MediatR;

namespace CodeHero.YouTubeDislikeCounter.Application.Commands.GetVideo
{
    public class GetVideoRequest : IRequest<GetVideoResponse>
    {
        public string Id { get; set; }
    }
}
