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
        private readonly IDeletableEntityRepository<Animal> animalRepository;
        private readonly IDeletableEntityRepository<Baggage> baggageRepository;
        private readonly IDeletableEntityRepository<Vehicle> vehicleRepository;

        public BookingsService(
            IDeletableEntityRepository<Booking> bookingRepository,
            IDeletableEntityRepository<Animal> animalRepository,
            IDeletableEntityRepository<Baggage> baggageRepository,
            IDeletableEntityRepository<Vehicle> vehicleRepository)
        {
            this.bookingRepository = bookingRepository;
            this.animalRepository = animalRepository;
            this.baggageRepository = baggageRepository;
            this.vehicleRepository = vehicleRepository;
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
                .Include(x => x.Animal)
                .Include(x => x.Baggage)
                .Include(x => x.Vehicle)
                .FirstOrDefault(x => x.Id.Equals(id));

            if (booking.Animal is not null)
            {
                this.animalRepository.Delete(booking.Animal);
            }

            if (booking.Baggage is not null)
            {
                this.baggageRepository.Delete(booking.Baggage);
            }

            if (booking.Vehicle is not null)
            {
                this.vehicleRepository.Delete(booking.Vehicle);
            }

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
