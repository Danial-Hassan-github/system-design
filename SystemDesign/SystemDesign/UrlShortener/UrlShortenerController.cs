using Microsoft.AspNetCore.Mvc;

namespace SystemDesign.UrlShortener
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly UrlShortenerService _urlShortenerService;

        public UrlShortenerController(UrlShortenerService urlShortenerService)
        {
            _urlShortenerService = urlShortenerService;
        }

        [HttpGet("shorten")]
        public IActionResult GetShortUrl(string longUrl)
        {
            return Ok(_urlShortenerService.ShortenUrl(longUrl));
        }

        [HttpGet("expand")]
        public IActionResult ExpandUrl(string shortUrl)
        {
            return Ok(_urlShortenerService.ExpandUrl(shortUrl));
        }
    }
}
