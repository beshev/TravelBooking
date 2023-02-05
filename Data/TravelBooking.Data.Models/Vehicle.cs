namespace TravelBooking.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TravelBooking.Common;
    using TravelBooking.Data.Common.Models;

    public class Vehicle : BaseDeletableModel<string>
    {
        public Vehicle()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(DataConstants.VehicleTypeMaxLength)]
        public string Type { get; set; }

        [Required]
        public string BookingId { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
