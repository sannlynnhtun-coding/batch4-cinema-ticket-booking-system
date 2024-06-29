using Batch4.Api.CinemaTicketBookingSystem.Database;
using Microsoft.Identity.Client;

namespace Batch4.Api.CinemaTicketBookingSystem.Models.BookingModel;

public class BookingResponseModel
{
    public string VoucherNo { get; set; }
    public string CustomerName { get; set; }
    public string MovieName { get; set; }
    public string SeatNumber { get; set; }
    public DateTime Bookingtime { get; set; }
}
