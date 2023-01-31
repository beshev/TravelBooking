namespace TravelBooking.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TravelBooking.Services.Data.Bookings;
    using TravelBooking.Web.Infrastructure.Extensions;
    using TravelBooking.Web.ViewModels.Bookings;

    public class BookingsController : BaseController
    {
        private readonly IBookingsService bookingsService;

        public BookingsController(IBookingsService bookingsService)
        {
            this.bookingsService = bookingsService;
        }

        public IActionResult Travel()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Travel(BookingInputBaseModel model)
        {
            model.ApplicationUserId = this.User.GetUserId();
            await this.bookingsService.CreateBookingAsync(model);
            return this.RedirectToAction(nameof(this.Travel));
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
