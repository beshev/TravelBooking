namespace TravelBooking.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TravelBooking.Common;
    using TravelBooking.Data.Common.Models;

    public class Animal : BaseDeletableModel<Guid>
    {
        public Animal()
        {
            this.Id = Guid.NewGuid();
        }

        [Required]
        [MaxLength(DataConstants.BreedMaxLength)]
        public string Breed { get; set; }

        public Guid BookingId { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
