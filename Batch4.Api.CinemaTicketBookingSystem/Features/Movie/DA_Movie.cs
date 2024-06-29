using Batch4.Api.CinemaTicketBookingSystem.Database;
using Batch4.Api.CinemaTicketBookingSystem.Models.MovieModel;

namespace Batch4.Api.CinemaTicketBookingSystem.Features.Movie;

public class DA_Movie
{
    private readonly AppDbContext _context;
    public DA_Movie()
    {
        _context = new AppDbContext();
    }
    public List<TblMovie> GetMovies()
    {
        var list = _context.Movies.ToList();
        
        return list;
    }
}
