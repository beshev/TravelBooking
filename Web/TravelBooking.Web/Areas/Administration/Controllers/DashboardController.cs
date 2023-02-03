namespace TravelBooking.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TravelBooking.Services.Data.Bookings;
    using TravelBooking.Web.ViewModels.Bookings;

    public class DashboardController : AdministrationController
    {
        private readonly IBookingsService bookingsService;

        public DashboardController(IBookingsService bookingsService)
        {
            this.bookingsService = bookingsService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await this.bookingsService.GetAllAsync<BookingViewModel>();
            return this.View(viewModel);
        }

        public async Task<IActionResult> Remove(string id)
        {
            await this.bookingsService.DeleteBookingAsync(id);
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
