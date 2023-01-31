namespace TravelBooking.Web.ViewModels.Bookings
{
    using TravelBooking.Data.Models;
    using TravelBooking.Services.Mapping;

    public class BaggageInputModel : IMapTo<Baggage>
    {
        public double Weight { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }
    }
}
