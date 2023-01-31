namespace TravelBooking.Web.ViewModels.Bookings
{
    using System.ComponentModel.DataAnnotations;

    public class BaggageInputModel : BookingInputBaseModel
    {
        public double Weight { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        [Required]
        public string BookingId { get; set; }
    }
}
