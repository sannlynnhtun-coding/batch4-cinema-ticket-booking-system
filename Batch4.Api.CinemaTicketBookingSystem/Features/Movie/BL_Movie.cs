using Batch4.Api.CinemaTicketBookingSystem.Models.MovieModel;

namespace Batch4.Api.CinemaTicketBookingSystem.Features.Movie
{
    public class BL_Movie
    {
        private readonly DA_Movie _movie;
        public BL_Movie()
        {
            _movie = new DA_Movie();
        }
        public List<MovieList> GetMovies()
        {
            var list = _movie.GetMovies();
            return list;
        }
    }
}
