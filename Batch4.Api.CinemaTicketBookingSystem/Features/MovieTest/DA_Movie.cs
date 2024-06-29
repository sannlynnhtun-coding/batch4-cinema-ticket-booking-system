using Batch4.Api.CinemaTicketBookingSystem.Database;
using Batch4.Api.CinemaTicketBookingSystem.Models.MovieModel;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Batch4.Api.CinemaTicketBookingSystem.Features.MovieTest;

public class DA_Movie
{
    private readonly AppDbContext _context;
    private readonly IDbConnection _connection;

    public DA_Movie(AppDbContext context, IDbConnection connection)
    {
        _context = context;
        _connection = connection;
    }

    public async Task<MovieList> GetList()
    {
        string query = "SELECT MoveName,Descriptoin FROM Tbl_Movie;";
        var lst = await _connection.QueryAsync<MovieResponseModel>(query);
        var model = new MovieList()
        {
            lst = lst.ToList(),
        };
        return model;
    }
}
