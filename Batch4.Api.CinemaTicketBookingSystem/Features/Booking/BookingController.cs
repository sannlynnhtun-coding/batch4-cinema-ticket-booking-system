using Batch4.Api.CinemaTicketBookingSystem.Models.BookingModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Batch4.Api.CinemaTicketBookingSystem.Features.Booking
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BL_Booking _bL_Booking;

        public BookingController(BL_Booking bL_Booking)
        {
            _bL_Booking = bL_Booking;
        }

        [HttpPost]
        public async Task<IActionResult> BookingResponse(BookingRequestModel requestModel)
        {
            var model = new BookingResponseModel();
            try
            {
                model = await _bL_Booking.BookingResponse(requestModel);
                if (model is null)
                {
                    return BadRequest("Model is Null");
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
               return BadRequest(ex.ToString());
            }
        }
    }
}
