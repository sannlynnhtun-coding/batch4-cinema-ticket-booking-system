using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Batch4.Api.CinemaTicketBookingSystem.Features.Movie
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly BL_Movie _bL_Movie;

        public MovieController(BL_Movie bL_Movie)
        {
            _bL_Movie = bL_Movie;
        }

        [HttpGet]
        public IActionResult Read()
        {
            var item = _bL_Movie.GetMovies();
            return Ok(item);
        }
    }
}
