namespace TravelBooking.Web.ViewModels.Bookings
{
    using System.ComponentModel.DataAnnotations;

    using TravelBooking.Common;
    using TravelBooking.Data.Models;
    using TravelBooking.Services.Mapping;

    public class BaggageInputModel : IMapTo<Baggage>
    {
        [Display(Name = GlobalConstants.Weight)]
        public double Weight { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [Display(Name = GlobalConstants.Height)]
        public double Height { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [Display(Name = GlobalConstants.Width)]
        public double Width { get; set; }
    }
}
