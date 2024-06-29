using Batch4.Api.CinemaTicketBookingSystem.Database;
using Batch4.Api.CinemaTicketBookingSystem.Models.MovieModel;

namespace Batch4.Api.CinemaTicketBookingSystem.Features.Movie
{
    public class BL_Movie
    {
        private readonly DA_Movie _da_movie;
        public BL_Movie()
        {
            _da_movie = new DA_Movie();
        }
        public List<TblMovie> GetMovies()
        {
            var list = _da_movie.GetMovies();
            return list;
        }
    }
}
