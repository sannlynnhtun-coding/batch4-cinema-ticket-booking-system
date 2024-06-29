using Batch4.Api.CinemaTicketBookingSystem.Database;
using Batch4.Api.CinemaTicketBookingSystem.Models.BookingModel;
using Batch4.Api.CinemaTicketBookingSystem.Models.MovieModel;
using Microsoft.EntityFrameworkCore;

namespace Batch4.Api.CinemaTicketBookingSystem.Features.Booking;

public class DA_Booking
{
    private readonly AppDbContext _context;

    public DA_Booking(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> IsExistSeatMovieCode(string seatMovieCode)
    {
        var item = await _context.Bookings.FirstOrDefaultAsync(x =>
            x.SeatMovieCode == seatMovieCode
        );
        if (item == null)
            throw new Exception("Invalid SeatMovieCode");

        return true;
    }

    public async Task<BookingRequestModel> CreateBooking(BookingRequestModel reqModel)
    {

        return;
    }
}
