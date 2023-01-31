namespace TravelBooking.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TravelBooking.Common;
    using TravelBooking.Data.Common.Models;

    public class Animal : BaseDeletableModel<string>
    {
        public Animal()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(DataConstants.BreedMaxLength)]
        public string Breed { get; set; }

        [Required]
        public string BookingId { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
