namespace TravelBooking.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsersService
    {
        public Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        public Task<int> Vote<TModel>(string userId, bool isPositive);
    }
}
