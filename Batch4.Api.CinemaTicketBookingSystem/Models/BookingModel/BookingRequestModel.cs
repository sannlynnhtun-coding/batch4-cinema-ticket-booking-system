namespace Batch4.Api.CinemaTicketBookingSystem.Models.BookingModel;

public class BookingRequestModel
{
    public string? SeatMovieCode { get; set; }

    public bool IsValid()
    {
        try
        {
            if (SeatMovieCode is null)
                throw new Exception("SeatMovieCode can't be null.");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        return true;
    }
}
