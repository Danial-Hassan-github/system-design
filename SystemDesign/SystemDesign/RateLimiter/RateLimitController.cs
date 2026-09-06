using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace SystemDesign.RateLimiter
{
    [ApiController]
    [Route("api/[controller]")]
    public class RateLimitController : ControllerBase
    {
        [HttpGet("fixed")]
        [EnableRateLimiting("fixed")]
        public IActionResult FixedWindow()
        {
            return Ok("Fixed window request accepted.");
        }

        [HttpGet("sliding")]
        [EnableRateLimiting("sliding")]
        public IActionResult SlidingWindow()
        {
            return Ok("Sliding window request accepted.");
        }

        [HttpGet("token")]
        [EnableRateLimiting("token")]
        public IActionResult TokenBucket()
        {
            return Ok("Token bucket request accepted.");
        }

        [HttpGet("concurrency")]
        [EnableRateLimiting("concurrency")]
        public IActionResult Concurrency()
        {
            return Ok("Concurrency request accepted.");
        }
    }
}
