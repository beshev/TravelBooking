namespace TravelBooking.Web.ViewModels.Bookings
{
    using System.ComponentModel.DataAnnotations;

    using TravelBooking.Common;

    public class BookingInputBaseModel
    {
        [Required]
        [MaxLength(DataConstants.FirstNameMaxLength)]
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

        public string UserId { get; set; }
    }
}
