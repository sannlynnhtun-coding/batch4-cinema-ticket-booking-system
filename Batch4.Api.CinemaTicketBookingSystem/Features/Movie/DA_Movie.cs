using Batch4.Api.CinemaTicketBookingSystem.Database;
using Batch4.Api.CinemaTicketBookingSystem.Models.MovieModel;
using Dapper;
using Microsoft.AspNetCore.Mvc;
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
        try
        {
            string query = "SELECT MovieCode, MovieName, Description FROM Tbl_Movie";
            var lst = await _connection.QueryAsync<MovieResponseModel>(query);
            var model = new MovieList()
            {
                lst = lst.ToList()
            };
            return model;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    public async Task<int> CreateMovie(TblMovie movie)
    {
        try
        {
            string query = @"INSERT INTO [dbo].[Tbl_Movie]
           ([MovieCode]
           ,[MovieName]
           ,[Description])
     VALUES
           (@MovieCode
           ,@MovieName
           ,@Description)";

            var result = await _connection.ExecuteAsync(query, movie);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    public async Task<int> UpdateMovie(int id, TblMovie movie)
    {
        try
        {
            var item = new TblMovie
            {
                MovieId = id,
                MovieCode = movie.MovieCode,
                MovieName = movie.MovieName,
                Description = movie.Description,

            };
            string query = @"UPDATE [dbo].[Tbl_Movie]
                       SET [MovieCode] = @MovieCode
                          ,[MovieName] = @MovieName
                          ,[Description] = @Description
                     WHERE MovieId = @MovieId";

            var result = await _connection.ExecuteAsync(query, item);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public async Task<int> DeleteMovie(int id)
    {
        try
        {
            var item = new TblMovie
            {
                MovieId = id,
            };
            string query = "DELETE FROM Tbl_Movie WHERE MovieId = @MovieId";

            var result = await _connection.ExecuteAsync(query, item);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}
