namespace TravelBooking.Web.ViewModels.Bookings
{
    using System.ComponentModel.DataAnnotations;

    using TravelBooking.Common;

    public class AnimaInputModel : BookingInputBaseModel
    {
        [Required]
        [MaxLength(DataConstants.BreedMaxLength)]
        public string Breed { get; set; }

        [Required]
        public string BookingId { get; set; }
    }
}
