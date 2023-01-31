namespace TravelBooking.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TravelBooking.Common;
    using TravelBooking.Data.Common.Models;

    public class Baggage : BaseDeletableModel<string>
    {
        public Baggage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public double Weight { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        [Required]
        public string BookingId { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
