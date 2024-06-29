using Batch4.Api.CinemaTicketBookingSystem.Database;
using Batch4.Api.CinemaTicketBookingSystem.Models.BookingModel;
using Batch4.Api.CinemaTicketBookingSystem.Models.MovieModel;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Batch4.Api.CinemaTicketBookingSystem.Features.Booking;

public class DA_Booking
{
    private readonly IDbConnection _connection;
    private readonly AppDbContext _context;

    public DA_Booking(AppDbContext context, IDbConnection connection)
    {
        _context = context;
        _connection = connection;
    }

    public async Task<bool> IsExistSeatMovieCode(string seatMovieCode)
    {
        var item = await _context.Bookings.FirstOrDefaultAsync(x =>
            x.SeatMovieCode == seatMovieCode
        );
        if (item is null)
            throw new Exception("Invalid SeatMovieCode");

        return true;
    }

    public async Task<string> CreateCustomer(string customerName)
    {
        string query = @"INSERT INTO [dbo].[Tbl_Customer]
           ,[CustomerName])
     VALUES
           (@CustomerName)";

        int result = await _connection.ExecuteAsync(query, new
        {
            CustomerName = customerName,
        });
        var message = result > 0 ? "Operation Successful" : "Operation Fail";

        return message;
    }

    public async Task<string> CreateBooking(BookingRequestModel reqModel)
    {
        await _context.Bookings.AddAsync(new TblBooking
        {
            SeatMovieCode = reqModel.SeatMovieCode!,
            CustomerName = reqModel.CustomerName,
            BookingHistory = DateTime.Now,
        });
        int result = await _context.SaveChangesAsync();
        string message = result > 0 ? "Operation Successful" : "Operation Fail";
        return message;
    }

    public async Task<BookingResponseModel> BookingResponse(BookingRequestModel reqModel)
    {
        var query = @"SELECT B.SeatMovieCode AS VoucherNo,
                       B.CustomerName,
                       M.MovieName,
                       SM.SeatCode,
                       ST.Showtime As ShowTime,
                       B.BookingHistory AS BookingTime 
                FROM Tbl_Booking AS B
                INNER JOIN Tbl_SeatMovie AS SM ON SM.SeatMovieCode = B.SeatMovieCode
                INNER JOIN Tbl_Movie AS M ON SM.MovieCode = M.MovieCode
                INNER JOIN Tbl_ShowTime AS ST ON ST.MovieCode = M.MovieCode
                WHERE B.SeatMovieCode = @SeatMovieCode;";

        await IsExistSeatMovieCode(reqModel.SeatMovieCode!);
        await CreateCustomer(reqModel.CustomerName);
        await CreateBooking(reqModel);
        var item = await _connection.QueryAsync<BookingResponseModel>(query, new
        {
            SeatMovieCode = reqModel.SeatMovieCode
        });
        var data = item.FirstOrDefault();   
        var model = new BookingResponseModel()
        {
            VoucherNo = data.VoucherNo,
            CustomerName = data.CustomerName,
            MovieName = data.MovieName,
            SeatNumber = data.SeatNumber,
            Bookingtime = data.Bookingtime
        };
        return model;
    }
}
