namespace TravelBooking.Web.ViewModels.Bookings
{
    using TravelBooking.Data.Models;
    using TravelBooking.Services.Mapping;
    using TravelBooking.Web.ViewModels.Users;

    public class BookingViewModel : BookingInputBaseModel, IMapFrom<Booking>
    {
        public string Id { get; set; }

        public virtual UserViewModel ApplicationUser { get; set; }
    }
}
