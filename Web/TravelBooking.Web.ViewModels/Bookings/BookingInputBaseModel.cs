﻿namespace TravelBooking.Web.ViewModels.Bookings
{
    using System.ComponentModel.DataAnnotations;

    using TravelBooking.Common;
    using TravelBooking.Data.Models;
    using TravelBooking.Services.Mapping;

    public class BookingInputBaseModel : IMapTo<Booking>
    {
        [Required]
        [MaxLength(DataConstants.FirstNameMaxLength)]
        [Display(Name = GlobalConstants.FirstName)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(DataConstants.LastNameMaxLength)]
        [Display(Name = GlobalConstants.LastName)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(DataConstants.PhoneNumberMaxLength)]
        [Display(Name = GlobalConstants.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(DataConstants.CountryMaxLength)]
        [Display(Name = GlobalConstants.OriginCountry)]
        public string OriginCountry { get; set; }

        [Required]
        [MaxLength(DataConstants.AddressMaxLength)]
        [Display(Name = GlobalConstants.OriginAddress)]
        public string OriginAddress { get; set; }

        [Required]
        [MaxLength(DataConstants.CityMaxLength)]
        [Display(Name = GlobalConstants.OriginCity)]
        public string OriginCity { get; set; }

        [Required]
        [MaxLength(DataConstants.CountryMaxLength)]
        [Display(Name = GlobalConstants.DestinationCountry)]
        public string DestinationCountry { get; set; }

        [Required]
        [MaxLength(DataConstants.AddressMaxLength)]
        [Display(Name = GlobalConstants.DestinationAddress)]
        public string DestinationAddress { get; set; }

        [Required]
        [MaxLength(DataConstants.CityMaxLength)]
        [Display(Name = GlobalConstants.DestinationCity)]
        public string DestinationCity { get; set; }

        public string ApplicationUserId { get; set; }

        public AnimaInputModel Animal { get; set; }

        public BaggageInputModel Baggage { get; set; }
    }
}
