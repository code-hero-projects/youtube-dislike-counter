using CodeHero.YouTubeDislikeCounter.Api.Requests;
using CodeHero.YouTubeDislikeCounter.Application.Commands.GetVideo;
using CodeHero.YouTubeDislikeCounter.Application.Commands.UpdateDislikes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeHero.YouTubeDislikeCounter.Api.Controllers
{
    [Route("api/video/{id}")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VideoController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetVideo(string id)
        {
            var videoRequest = new GetVideoRequest() { Id = id };
            var response = await _mediator.Send(videoRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVideo(string id, UpdateDislikesRequestModel request)
        {
            var updateDislikesRequest = new UpdateDislikesRequest()
            {
                VideoId = id,
                IsDislike = request.IsDislike
            };

            var response = await _mediator.Send(updateDislikesRequest);
            return Ok(response);
        }
    }
}
