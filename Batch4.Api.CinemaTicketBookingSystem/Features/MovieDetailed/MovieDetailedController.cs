using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Batch4.Api.CinemaTicketBookingSystem.Features.MovieDetailed
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieDetailedController : ControllerBase
    {
        private readonly BL_MovieDetailed _bL_MovieDetailed;

        public MovieDetailedController(BL_MovieDetailed bL_MovieDetailed)
        {
            _bL_MovieDetailed = bL_MovieDetailed;
        }

        [HttpGet("{movieCode}")]
        public async Task<IActionResult> GetMovieDetailed(string movieCode)
        {
            var model = await _bL_MovieDetailed.GetMovieDetail(movieCode);
            return Ok(model);
        }

    }
}
