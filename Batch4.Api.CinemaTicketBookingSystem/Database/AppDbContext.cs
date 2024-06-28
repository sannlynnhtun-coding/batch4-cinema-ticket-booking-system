using Microsoft.EntityFrameworkCore;

namespace Batch4.Api.CinemaTicketBookingSystem.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<TblBooking> Bookings { get; set; }
    public DbSet<TblCustomer> Customers { get; set; }
    public DbSet<TblMovie> Movies { get; set; }
    public DbSet<TblSeatMovie> SeatMovies { get; set; }
    public DbSet<TblShowTime> ShowTimes { get; set; }
}
