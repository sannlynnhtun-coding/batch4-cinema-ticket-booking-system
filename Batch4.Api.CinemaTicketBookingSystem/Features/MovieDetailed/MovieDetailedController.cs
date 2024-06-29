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

        [HttpGet]
        public IActionResult getSeatDetailed()
        {
            var item = _bL_MovieDetailed.GetDetailedSeatMovie();
            return Ok(item);
        }

        [HttpGet("{movieCode}")]
        public IActionResult GetMovieDetailed(string movieCode)
        {
            var item = _bL_MovieDetailed.GetMovieDetailed(movieCode);
            if(item == null)
            {
                return NotFound("no data found");
            }
            return Ok(item);
        }

    }
}
