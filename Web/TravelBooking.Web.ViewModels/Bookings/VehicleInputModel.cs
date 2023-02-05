namespace TravelBooking.Web.ViewModels.Bookings
{
    using System.ComponentModel.DataAnnotations;

    using TravelBooking.Common;
    using TravelBooking.Data.Models;
    using TravelBooking.Services.Mapping;

    public class VehicleInputModel : IMapTo<Vehicle>, IMapFrom<Vehicle>
    {
        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [MaxLength(DataConstants.VehicleTypeMaxLength)]
        public string Type { get; set; }
    }
}
