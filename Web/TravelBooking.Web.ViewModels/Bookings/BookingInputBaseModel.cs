namespace TravelBooking.Web.ViewModels.Bookings
{
    using System.ComponentModel.DataAnnotations;

    using TravelBooking.Common;
    using TravelBooking.Data.Models;
    using TravelBooking.Services.Mapping;

    public class BookingInputBaseModel : IMapTo<Booking>
    {
        [Required]
        [MaxLength(DataConstants.FirstNameMaxLength)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(DataConstants.LastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(DataConstants.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(DataConstants.CountryMaxLength)]
        public string OriginCountry { get; set; }

        [Required]
        [MaxLength(DataConstants.AddressMaxLength)]
        public string OriginAddress { get; set; }

        [Required]
        [MaxLength(DataConstants.CityMaxLength)]
        public string OriginCity { get; set; }

        [Required]
        [MaxLength(DataConstants.CountryMaxLength)]
        public string DestinationCountry { get; set; }

        [Required]
        [MaxLength(DataConstants.AddressMaxLength)]
        public string DestinationAddress { get; set; }

        [Required]
        [MaxLength(DataConstants.CityMaxLength)]
        public string DestinationCity { get; set; }

        public string ApplicationUserId { get; set; }

        public AnimaInputModel Animal { get; set; }
    }
}
