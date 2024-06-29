namespace Batch4.Api.CinemaTicketBookingSystem.Models.MovieDetailedModel
{
    public class DetailedSeatMovie
    {
        public string? SeatMovieCode { get; set; }
        public string? ShowtimeCode { get; set; }
        public DateTime MovieTime { get; set; }
    }
    public class MovieDetailedResponseModel
    {
        public string? MoiveCode { get; set; }
        public string? MovieName { get; set; }
        public string? Description { get; set; }
        public List<DetailedSeatMovie>? SeatMovieList { get; set;}
    }
}
