
namespace Batch4.Api.CinemaTicketBookingSystem.Models.MovieModel;

public class MovieResponseModel
{
    public string MoiveCode { get; set; }
    public string MovieName { get; set; }
    public string Description { get; set; }
    
}

public class MovieList
{
    public List<MovieResponseModel> lst { get; set; }
}

