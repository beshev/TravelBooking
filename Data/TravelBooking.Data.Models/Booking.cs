namespace TravelBooking.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TravelBooking.Common;
    using TravelBooking.Data.Common.Models;

    public class Booking : BaseDeletableModel<Guid>
    {
        public Booking()
        {
            this.Id = Guid.NewGuid();
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

        [Required]
        public string OriginCountry { get; set; }

        [Required]
        public string OriginAddress { get; set; }

        [Required]
        public string OriginCity { get; set; }

        [Required]
        public string DestinationCountry { get; set; }

        [Required]
        public string DestinationAddress { get; set; }

        [Required]
        public string DestinationCity { get; set; }

        public virtual Baggage Baggage { get; set; }

        public virtual Animal Animal { get; set; }
    }
}
