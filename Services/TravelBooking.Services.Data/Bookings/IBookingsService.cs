namespace TravelBooking.Services.Data.Bookings
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookingsService
    {
        Task<IEnumerable<TModel>> GetAllAsync<TModel>(bool? isDeleted = null);

        Task CreateBookingAsync<TModel>(TModel model);

        Task DeleteBookingAsync(string id);
    }
}
