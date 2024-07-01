using Batch4.Api.CinemaTicketBookingSystem.Database;
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
        public async Task<IActionResult> Read()
        {
            try
            {
                var item = await _bL_Movie.GetMovies();
                if(item is null)
                    return BadRequest("Moives are Unavaliable");
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(TblMovie movie)
        {
            var result = await _bL_Movie.CreateMovie(movie);
            string message = result > 0 ? "Saving Success!" : "Saving Fail!";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TblMovie movie)
        {
            var result = await _bL_Movie.UpdateMovie(id, movie);
            string message = result > 0 ? "Updating Success!" : "Updating Fail!";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bL_Movie.DeleteMovie(id);
            string message = result > 0 ? "Deleting Success!" : "Deleting Fail!";
            return Ok(message);
        }
    }
}
