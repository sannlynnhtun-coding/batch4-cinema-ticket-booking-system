using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Batch4.Api.CinemaTicketBookingSystem.Database;

[Table("Tbl_Booking")]
public class TblBooking
{
    [Key]
    public int BookingId { get; set; }
    public string SeatMovieCode { get; set; }
    public string CustomerName { get; set; }
    public DateTime BookingHistory { get; set; }
}
