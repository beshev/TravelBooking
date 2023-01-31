namespace TravelBooking.Services.Data.Bookings
{
    using System.Threading.Tasks;

    public interface IBookingsService
    {
        Task CreateBookingAsync<TModel>(TModel model);
    }
}
