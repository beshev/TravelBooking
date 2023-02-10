namespace TravelBooking.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TravelBooking.Data.Common.Repositories;
    using TravelBooking.Data.Models;
    using TravelBooking.Services.Mapping;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
        {
            return await this.usersRepository
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync();
        }

        // TODO: Make this AJAX
        public async Task<int> Vote<TModel>(string userId, bool isPositive)
        {
            var user = await this.usersRepository
                .All()
                .FirstOrDefaultAsync();

            user.Rate = isPositive
                ? ++user.Rate
                : --user.Rate;

            this.usersRepository.Update(user);
            await this.usersRepository.SaveChangesAsync();

            return user.Rate;
        }
    }
}
