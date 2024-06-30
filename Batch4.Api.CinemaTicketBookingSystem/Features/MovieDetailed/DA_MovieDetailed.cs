using Batch4.Api.CinemaTicketBookingSystem.Database;
using Batch4.Api.CinemaTicketBookingSystem.Models.MovieDetailedModel;
using Batch4.Api.CinemaTicketBookingSystem.Models.MovieModel;
using Dapper;
using System.Data;

namespace Batch4.Api.CinemaTicketBookingSystem.Features.MovieDetailed
{
    public class DA_MovieDetailed
    {
        public readonly AppDbContext _context;
        private readonly IDbConnection _dbConnection;

        public DA_MovieDetailed(AppDbContext context, IDbConnection dbConnection)
        {
            _context = context;
            _dbConnection = dbConnection;
        }

        public List<DetailedSeatMovie> GetDetailedSeatMovie()
        {
            string query = @"select * from Tbl_SeatMovie;";
            var lst = _dbConnection.Query<DetailedSeatMovie>(query).ToList();
            return lst;
        }

        public MovieDetailedResponseModel GetMovieDetailed(string movieCode)
        {
            string query = @"SELECT m.MovieCode, m.MovieName, m.Description, sm.SeatMovieCode, st.Showtime
FROM Tbl_Movie m
INNER JOIN Tbl_SeatMovie sm ON m.MovieCode = sm.MovieCode
INNER JOIN Tbl_ShowTime st ON m.MovieCode = st.MovieCode
WHERE m.MovieCode = @MovieCode;";

            var item = _dbConnection.QueryFirstOrDefault<MovieDetailedResponseModel>(query, new {MovieCode = movieCode});

            return item;
        }
    }
}
