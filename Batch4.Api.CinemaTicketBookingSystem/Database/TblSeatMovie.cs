using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Batch4.Api.CinemaTicketBookingSystem.Database;

[Table("Tbl_SeatMovie")]
public class TblSeatMovie
{
    [Key]
    public int SeatMovieId { get; set; }
    public string SeatMovieCode { get; set; }
    public string MovieCode { get; set; }
    public string SeatCode { get; set; }
}
