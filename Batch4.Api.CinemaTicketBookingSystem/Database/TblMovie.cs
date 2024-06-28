using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Batch4.Api.CinemaTicketBookingSystem.Database;

[Table("Tbl_Movie")]
public class TblMovie
{
    [Key]
    public int MovieId { get; set; }
    public string MoiveCode { get; set; }
    public string MovieName { get; set; }
    public string Description { get; set; }
}
