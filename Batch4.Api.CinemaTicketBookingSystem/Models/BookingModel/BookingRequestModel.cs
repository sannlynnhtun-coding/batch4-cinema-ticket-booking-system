using Microsoft.Identity.Client;

namespace Batch4.Api.CinemaTicketBookingSystem.Models.BookingModel;

public class BookingRequestModel
{
    public string? SeatMovieCode { get; set; }
    public string CustomerName { get; set; }
}
