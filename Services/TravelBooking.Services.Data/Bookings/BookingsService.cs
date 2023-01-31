namespace TravelBooking.Services.Data.Bookings
{
    using System.Threading.Tasks;

    using TravelBooking.Data.Common.Repositories;
    using TravelBooking.Data.Models;
    using TravelBooking.Services.Mapping;

    public class BookingsService : IBookingsService
    {
        private readonly IDeletableEntityRepository<Booking> bookingRepository;

        public BookingsService(IDeletableEntityRepository<Booking> bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public async Task CreateBookingAsync<TModel>(TModel model)
        {
            var booking = AutoMapperConfig.MapperInstance.Map<Booking>(model);

            await this.bookingRepository.AddAsync(booking);
            await this.bookingRepository.SaveChangesAsync();
        }
    }
}
