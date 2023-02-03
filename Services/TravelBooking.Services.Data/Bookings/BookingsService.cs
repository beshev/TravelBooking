namespace TravelBooking.Services.Data.Bookings
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
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

        public async Task DeleteBookingAsync(string id)
        {
            var booking = this.bookingRepository
                .All()
                .FirstOrDefault(x => x.Id.Equals(id));

            this.bookingRepository.Delete(booking);
            await this.bookingRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>(bool? isDeleted = null)
        {
            var query = this.bookingRepository
                .AllAsNoTracking();

            if (isDeleted is not null)
            {
                query = query.Where(x => x.IsDeleted.Equals(isDeleted));
            }

            return await query
                .To<TModel>()
                .ToListAsync();
        }
    }
}
