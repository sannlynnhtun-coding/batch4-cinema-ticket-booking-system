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

        public async Task<MovieDetailResponseModel>GetMovieDetail(string movieCode)
        {
            var model = await _dA_MovieDetailed.GetMovieDetail(movieCode);
            return model;
        }
    }
}
