namespace Batch4.Api.CinemaTicketBookingSystem.Models.MovieModel;

public class Movies
{
    public string MovieName { get; set; }
    public string Description { get; set; }
}

public class MovieList
{
    public List<Movies> Lst { get; set; }
}