namespace Batch4.Api.CinemaTicketBookingSystem.Models.MovieDetailedModel
{
    public class MovieDetailResponseModel
    {
        public MovieDetailModel Movie { get; set; }
        public SeatList SeatNumber { get; set; }
        public AvailableSeatList AvailableSeats { get; set; }
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

    public class SeatList
    {
        public List<Seats> SeatNumber { get; set; }
    }

    public class AvailableSeatList
    {
        public List<Seats> AvailableSeatNumber { get; set; }
    }


}
