namespace TravelBooking.Data.Models
{
    using System;

    using TravelBooking.Data.Common.Models;

    public class Baggage : BaseDeletableModel<Guid>
    {
        public Baggage()
        {
            this.Id = Guid.NewGuid();
        }

        public double Weight { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public Guid BookingId { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
