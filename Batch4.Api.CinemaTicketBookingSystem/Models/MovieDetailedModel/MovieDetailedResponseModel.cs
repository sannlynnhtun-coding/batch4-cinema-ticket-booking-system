namespace Batch4.Api.CinemaTicketBookingSystem.Models.MovieDetailedModel;

public class MovieDetailResponseModel
{
    public MovieDetailModel Movie { get; set; }
    public List<Seats> SeatNumber { get; set; }
    public List<AvailableSeat> AvailableSeats { get; set; }
}

public class MovieDetailModel
{
    public string MovieName { get; set; }
    public string Description { get; set; }
    public DateTime ShowTime { get; set; }
}

public class Seats
{
    public string SeatCode { get; set; }
}

public class AvailableSeat
{
    public string SeatCode { get; set; }
}
