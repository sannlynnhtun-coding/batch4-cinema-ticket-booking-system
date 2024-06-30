using Batch4.Api.CinemaTicketBookingSystem.Models.BookingModel;

namespace Batch4.Api.CinemaTicketBookingSystem.Features.Booking;

public class BL_Booking
{
    private readonly DA_Booking _dA_booking;

    public BL_Booking(DA_Booking dA_booking)
    {
        _dA_booking = dA_booking;
    }

    public async Task<BookingResponseModel> BookingResponse(BookingRequestModel reqModel)
    {
        var model = new BookingResponseModel();
        try
        {
           model = await _dA_booking.BookingResponse(reqModel);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        return model;
    }
}
