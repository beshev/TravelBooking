namespace TravelBooking.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TravelBooking.Common;
    using TravelBooking.Data.Common.Models;

    public class Booking : BaseDeletableModel<string>
    {
        public Booking()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(DataConstants.FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(DataConstants.LastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(DataConstants.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        public string CustomerNote { get; set; }

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

        public virtual string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Baggage Baggage { get; set; }

        public virtual Animal Animal { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
