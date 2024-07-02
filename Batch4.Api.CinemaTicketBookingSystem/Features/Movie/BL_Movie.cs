using Batch4.Api.CinemaTicketBookingSystem.Database;
using Batch4.Api.CinemaTicketBookingSystem.Models.MovieModel;

namespace Batch4.Api.CinemaTicketBookingSystem.Features.Movie;

public class BL_Movie
{
    private readonly DA_Movie _dA_movie;

    public BL_Movie(DA_Movie dA_movie)
    {
        _dA_movie = dA_movie;
    }

    public async Task<MovieList> GetMovies()
    {
        var movie = await _dA_movie.GetMovies();
        if (movie is null) throw new Exception("Operation Fail");
        return movie;
    }
    public async Task<int> CreateMovie(TblMovie movie)
    {
        var result = await _dA_movie.CreateMovie(movie);
        return result;
    }
    public async Task<int> UpdateMovie(int id,TblMovie movie)
    {
        var result = await _dA_movie.UpdateMovie(id, movie);
        return result;
    }
    public async Task<int> DeleteMovie(int id)
    {
        var result = await _dA_movie.DeleteMovie(id);
        return result;
    }
}
