using System.Data;
using System.Data.SqlClient;
using Batch4.Api.CinemaTicketBookingSystem.Database;
using Batch4.Api.CinemaTicketBookingSystem.Models.BookingModel;
using Dapper;
using Microsoft.EntityFrameworkCore;

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
        var item = await _context.SeatMovies.FirstOrDefaultAsync(x =>
            x.SeatMovieCode == seatMovieCode
        );
        if (item is null)
            throw new Exception("Invalid SeatMovieCode");
        return true;
    }

    public async Task<bool> IsValidateMovieCode(string seatMovieCode)
    {
        var item = await _context.Bookings.FirstOrDefaultAsync(x =>
            x.SeatMovieCode == seatMovieCode
        );
        if (item is not null)
            throw new Exception("SeatMovie Is Already Taken");
        return true;
    }

    public async Task<string> CreateCustomer(string customerName)
    {
        string query = @"INSERT INTO Tbl_Customer (CustomerName) VALUES (@CustomerName)";
        int result = await _connection.ExecuteAsync(query, new { CustomerName = customerName, });
        var message = result > 0 ? "Operation Successful" : "Operation Fail";
        return message;
    }

    public async Task<string> CreateBooking(BookingRequestModel reqModel)
    {
        await _context.Bookings.AddAsync(
            new TblBooking
            {
                SeatMovieCode = reqModel.SeatMovieCode!,
                CustomerName = reqModel.CustomerName,
                BookingHistory = DateTime.Now,
            }
        );
        int result = await _context.SaveChangesAsync();
        string message = result > 0 ? "Operation Successful" : "Operation Fail";
        return message;
    }

    public async Task<BookingResponseModel> BookingResponse(BookingRequestModel reqModel)
    {
        try
        {
            var query =
                @"SELECT B.SeatMovieCode AS VoucherNo,B.CustomerName,M.MovieName,
                SM.SeatCode As SeatNumber,ST.Showtime As ShowTime, B.BookingHistory AS BookingTime 
                FROM Tbl_Booking AS B INNER JOIN Tbl_SeatMovie AS SM ON SM.SeatMovieCode = B.SeatMovieCode
                INNER JOIN Tbl_Movie AS M ON SM.MovieCode = M.MovieCode
                INNER JOIN Tbl_ShowTime AS ST ON ST.MovieCode = M.MovieCode
                WHERE B.SeatMovieCode = @SeatMovieCode;";

            var result = await IsExistSeatMovieCode(reqModel.SeatMovieCode!);
            if (!result)
                throw new Exception("Invalid SeatMovieCode");
            var resutlValidate = await IsValidateMovieCode(reqModel.SeatMovieCode!);
            if (!resutlValidate)
                throw new Exception("SeatMovie Is Already Taken");

            await CreateCustomer(reqModel.CustomerName);
            await CreateBooking(reqModel);
            var item = await _connection.QueryAsync<BookingResponseModel>(
                query,
                new { SeatMovieCode = reqModel.SeatMovieCode }
            );
            var data = item.FirstOrDefault();
            var model = new BookingResponseModel()
            {
                VoucherNo = data.VoucherNo,
                CustomerName = data.CustomerName,
                MovieName = data.MovieName,
                SeatNumber = data.SeatNumber,
                ShowTime = data.ShowTime,
                Bookingtime = data.Bookingtime,
                ThankYou = "Thank you so much. Have a Good Day."
            };
            return model;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}
