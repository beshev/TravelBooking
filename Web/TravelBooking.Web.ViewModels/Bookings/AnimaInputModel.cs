namespace TravelBooking.Web.ViewModels.Bookings
{
    using System.ComponentModel.DataAnnotations;

    using TravelBooking.Common;
    using TravelBooking.Data.Models;
    using TravelBooking.Services.Mapping;

    public class AnimaInputModel : IMapTo<Animal>, IMapFrom<Animal>
    {
        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [MaxLength(DataConstants.BreedMaxLength)]
        [Display(Name = GlobalConstants.Breed)]
        public string Breed { get; set; }
    }
}
