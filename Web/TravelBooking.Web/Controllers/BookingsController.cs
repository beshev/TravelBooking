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

        public IActionResult Animal()
        {
            return this.View();
        }

        public IActionResult Baggage()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Booking(BookingInputBaseModel model, string returnUrl)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(returnUrl);
            }

            model.ApplicationUserId = this.User.GetUserId();
            await this.bookingsService.CreateBookingAsync(model);
            return this.RedirectToAction(nameof(this.SuccessBooking));
        }

        public IActionResult SuccessBooking()
        {
            return this.View();
        }
    }
}
