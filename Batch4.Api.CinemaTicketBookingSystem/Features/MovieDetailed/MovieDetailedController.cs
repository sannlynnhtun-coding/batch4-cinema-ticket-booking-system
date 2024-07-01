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
            try
            {
                var model = await _bL_MovieDetailed.GetMovieDetail(movieCode);
                if (model is null)
                    return BadRequest("Model not found");
                return Ok(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}
