namespace TravelBooking.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Linq;
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

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>(string currentUserId = null)
        {
            var query = this.usersRepository
                .AllAsNoTracking();

            if (!string.IsNullOrWhiteSpace(currentUserId))
            {
                query = query.Where(x => !x.Id.Equals(currentUserId));
            }

            return await query.To<TModel>().ToListAsync();
        }

        public async Task<int> VoteAsync(string userId, bool isPositive)
        {
            var user = await this.usersRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id.Equals(userId));

            user.Rate = isPositive
                ? ++user.Rate
                : --user.Rate;

            this.usersRepository.Update(user);
            await this.usersRepository.SaveChangesAsync();

            return user.Rate;
        }
    }
}
