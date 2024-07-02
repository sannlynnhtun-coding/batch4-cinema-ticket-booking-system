using Microsoft.Identity.Client;

namespace Batch4.Api.CinemaTicketBookingSystem.Models.BookingModel;

public class BookingRequestModel
{
    public string MovieCode { get; set; }
    public string SeatCode { get; set; }
    public string CustomerName { get; set; }
}
