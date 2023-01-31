namespace TravelBooking.Data.Models
{
    using System;

    using TravelBooking.Data.Common.Models;

    public class Address : BaseDeletableModel<Guid>
    {
        public Address()
        {
            this.Id = Guid.NewGuid();
        }

        public string Country { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }
    }
}
