using Batch4.Api.CinemaTicketBookingSystem.Database;
using Batch4.Api.CinemaTicketBookingSystem.Models.MovieModel;
using Dapper;
using System.Data;

namespace Batch4.Api.CinemaTicketBookingSystem.Features.Movie;

public class DA_Movie
{
    private readonly IDbConnection _connection;

    public DA_Movie(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<MovieList> GetMovies()
    {
        string query = "SELECT MovieName, Description FROM Tbl_Movie";
        var lst = await _connection.QueryAsync<MovieResponseModel>(query);
        var model = new MovieList()
        {
            lst = lst.ToList()
        };
        return model;
    }
}
