namespace TravelBooking.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TravelBooking.Web.ViewModels.Bookings;

    public class BookingsController : BaseController
    {
        public IActionResult Travel()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Travel(BookingInputBaseModel model)
        {
            return this.View();
        }

        public IActionResult Anima()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Anima(AnimaInputModel model)
        {
            return this.View();
        }

        public IActionResult Baggage()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Baggage(BaggageInputModel model)
        {
            return this.View();
        }
    }
}
