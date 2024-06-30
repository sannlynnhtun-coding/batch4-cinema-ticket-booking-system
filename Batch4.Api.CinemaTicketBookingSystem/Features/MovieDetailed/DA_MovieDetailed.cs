using Batch4.Api.CinemaTicketBookingSystem.Database;
using Batch4.Api.CinemaTicketBookingSystem.Models.MovieDetailedModel;
using Batch4.Api.CinemaTicketBookingSystem.Models.MovieModel;
using Dapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> IsExistMovieAsync(string movieCode)
        {
            try
            {
                var item = await _context.Movies.FirstOrDefaultAsync(x=>x.MovieCode == movieCode);
                if (item is null)
                {
                    throw new Exception("MovieCode is Invalid");
                }
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        public async Task<MovieDetailModel> MovieDetail(string movieCode)
        {
            try
            {
                string query = @"SELECT M.MovieName, M.Description, ST.MovieTime FROM Tbl_Movie AS M
            JOIN Tbl_ShowTime AS ST ON ST.MovieCode = M.MovieCode
            WHERE M.MovieCode = @MovieCode;";
                var result = await _dbConnection.QueryAsync<MovieDetailModel>(query, new
                {
                    MovieCode = movieCode
                });
                if(result is null)
                {
                    throw new Exception("Movie Code Invalid");
                }
                var item = result.FirstOrDefault();
                var model = new MovieDetailModel
                {
                    MovieName = item.MovieName,
                    Description = item.Description,
                    ShowTime = item.ShowTime,
                };
                return model;
            }
            catch(System.Exception ex)
            {
                throw new Exception(ex.ToString() );
            }
        }

        public async Task<SeatList> SeatList(string movieCode)
        {
            try
            {
                string query = @"SELECT SeatCode FROM Tbl_SeatMovie WHERE MovieCode = @MovieCode;";
                var result = await _dbConnection.QueryAsync<Seats>(query, new
                {
                    MovieCode = movieCode
                });
                if (result is null) { throw new Exception("Seat Invalid"); }
                var lst = result.ToList();
                var model = new SeatList()
                {
                    SeatNumber = lst
                };
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<AvailableSeatList> AvailableSeatList(string movieCode)
        {
            try
            {
                string query = @"SELECT SeatCode FROM Tbl_SeatMovie AS SM
                    WHERE SM.MovieCode = @MovieCode AND SM.SeatCode NOT IN (
                    SELECT SeatCode FROM Tbl_SeatMovie AS SM
                    JOIN Tbl_Booking AS B ON B.SeatMovieCode = SM.SeatMovieCode
                    WHERE MovieCode = @MovieCode);";

                var result = await _dbConnection.QueryAsync<Seats>(query, new
                {
                    MovieCode = movieCode
                });
                if (result is null) { throw new Exception("Seat Invalid"); };
                var lst = result.ToList();
                var model = new AvailableSeatList()
                {
                    AvailableSeatNumber = lst
                };
                return model;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString() );
            }
        }

        public async Task<MovieDetailResponseModel>GetMovieDetail(string movieCode)
        {
            try
            {
                bool result = await IsExistMovieAsync(movieCode);
                if (!result) throw new Exception("Invalid Movie Code");
                var movieDetail = await MovieDetail(movieCode);
                var seatList = await SeatList(movieCode);
                var availableSeatList = await AvailableSeatList(movieCode);

                var model = new MovieDetailResponseModel()
                {
                    Movie = movieDetail,
                    SeatNumber = seatList,
                    AvailableSeats = availableSeatList
                };
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        
    }
}
