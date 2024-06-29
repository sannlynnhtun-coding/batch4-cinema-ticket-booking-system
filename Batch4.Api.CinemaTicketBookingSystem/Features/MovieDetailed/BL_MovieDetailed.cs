using Batch4.Api.CinemaTicketBookingSystem.Models.MovieDetailedModel;

namespace Batch4.Api.CinemaTicketBookingSystem.Features.MovieDetailed
{
    public class BL_MovieDetailed
    {
        private readonly DA_MovieDetailed _dA_MovieDetailed;

        public BL_MovieDetailed(DA_MovieDetailed dA_MovieDetailed)
        {
            _dA_MovieDetailed = dA_MovieDetailed;
        }

        public List<DetailedSeatMovie> GetDetailedSeatMovie()
        {
            var lst = _dA_MovieDetailed.GetDetailedSeatMovie();
            return lst;
        }

        public MovieDetailedResponseModel GetMovieDetailed(string movieCode)
        {
            var item = _dA_MovieDetailed.GetMovieDetailed(movieCode);
            return item;
        }
    }
}
