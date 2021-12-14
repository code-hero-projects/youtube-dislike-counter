using MediatR;

namespace CodeHero.YouTubeDislikeCounter.Application.Commands.UpdateDislikes
{
    public class UpdateDislikesRequest : IRequest<UpdateDislikesResponse>
    {
        public string VideoId { get; set; }
        public bool IsDislike { get; set; }
    }
}
