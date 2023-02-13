namespace TravelBooking.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TravelBooking.Services.Data.Bookings;
    using TravelBooking.Services.Data.Users;
    using TravelBooking.Web.Infrastructure.Extensions;
    using TravelBooking.Web.ViewModels.Bookings;
    using TravelBooking.Web.ViewModels.Users;

    public class DashboardController : AdministrationController
    {
        private readonly IBookingsService bookingsService;
        private readonly IUsersService usersService;

        public DashboardController(
            IBookingsService bookingsService,
            IUsersService usersService)
        {
            this.bookingsService = bookingsService;
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> Bookings()
        {
            var viewModel = await this.bookingsService.GetAllAsync<BookingViewModel>();
            return this.View(viewModel);
        }

        public async Task<IActionResult> Users()
        {
            var viewModel = await this.usersService.GetAllAsync<UserViewModel>(this.User.GetUserId());
            return this.View(viewModel);
        }

        public async Task<IActionResult> Remove(string id)
        {
            await this.bookingsService.DeleteBookingAsync(id);
            return this.RedirectToAction(nameof(this.Bookings));
        }
    }
}
