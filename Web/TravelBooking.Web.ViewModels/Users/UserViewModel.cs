namespace TravelBooking.Web.ViewModels.Users
{
    using TravelBooking.Data.Models;
    using TravelBooking.Services.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public int Rate { get; set; }

        public string Email { get; set; }
    }
}
