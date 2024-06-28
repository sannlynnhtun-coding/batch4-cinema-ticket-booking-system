using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Batch4.Api.CinemaTicketBookingSystem.Database;

[Table("Tbl_Customer")]
public class TblCustomer
{
    [Key]
    public int CustomerId { get; set; }
    public string CustomerCode { get; set; }
    public string CustomerName { get; set; }
}
