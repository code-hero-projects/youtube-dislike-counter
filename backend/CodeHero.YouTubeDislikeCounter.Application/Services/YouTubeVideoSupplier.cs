using CodeHero.YouTubeDislikeCounter.Application.Configuration;
using CodeHero.YouTubeDislikeCounter.Application.Services.YouTubeApiResponse;
using CodeHero.YouTubeDislikeCounter.Domain.Model;
using CodeHero.YouTubeDislikeCounter.Domain.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace CodeHero.YouTubeDislikeCounter.Application.Services
{
    public class YouTubeVideoSupplier : IVideoSupplier
    {
        private readonly string _url;
        private readonly ILogger<YouTubeVideoSupplier> _logger;

        public YouTubeVideoSupplier(YouTubeConfiguration youTubeConfiguration, ILogger<YouTubeVideoSupplier> logger)
        {
            _url = youTubeConfiguration.ApiUrl;
            _logger = logger;
        }

        public async Task<Video> FetchVideo(string id)
        {
            var url = _url.Replace(ApplicationConstants.YouTubeVideoIdUrlVariable, id);
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await MapVideo(response, id);
            }
            else
            {
                _logger.LogError("Fetching video with id {0}", id);
                return new Video()
                {
                    Id = id,
                    Dislikes = 0
                };
            }
        }

        private static async Task<Video> MapVideo(HttpResponseMessage response, string id)
        {
            var result = await response.Content.ReadAsStringAsync();
            var youTubeApiResponse = JsonConvert.DeserializeObject<YouTubeResponse>(result);
            var dislikes = youTubeApiResponse.Items.First().Statistics.DislikeCount;

            return new Video()
            {
                Id = id,
                Dislikes = dislikes
            };
        }
    }
}
