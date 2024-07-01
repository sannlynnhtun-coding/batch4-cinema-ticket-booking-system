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

        public async Task<MovieDetailResponseModel> GetMovieDetail(string movieCode)
        {
            try
            {
                var model = await _dA_MovieDetailed.GetMovieDetail(movieCode);
                if (model is null)
                    throw new Exception("Movie is null");
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}