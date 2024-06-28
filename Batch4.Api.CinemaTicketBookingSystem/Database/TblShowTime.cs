using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Batch4.Api.CinemaTicketBookingSystem.Database;

[Table("Tbl_ShowTime")]
public class TblShowTime
{
    [Key]
    public int ShowtimeId { get; set; }
    public string ShowtimeCode { get; set; }
    public string MovieCode { get; set; }
    public DateTime MovieTime { get; set; }
}
