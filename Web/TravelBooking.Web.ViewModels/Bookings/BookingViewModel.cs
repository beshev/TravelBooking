namespace TravelBooking.Web.ViewModels.Bookings
{
    using TravelBooking.Data.Models;
    using TravelBooking.Services.Mapping;

    public class BookingViewModel : BookingInputBaseModel, IMapFrom<Booking>
    {
        public string Id { get; set; }
    }
}
