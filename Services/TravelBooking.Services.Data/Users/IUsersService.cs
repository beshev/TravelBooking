namespace TravelBooking.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsersService
    {
        public Task<IEnumerable<TModel>> GetAllAsync<TModel>(string currentUserId = null);

        public Task<int> VoteAsync(string userId, bool isPositive);
    }
}
