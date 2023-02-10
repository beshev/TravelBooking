namespace TravelBooking.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TravelBooking.Common;
    using TravelBooking.Services.Data.Users;
    using TravelBooking.Web.ViewModels.Users;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class UserVoteController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UserVoteController(
            IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public async Task<ActionResult<int>> Post([FromBody] UserVoteInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.UserId))
            {
                return this.BadRequest();
            }

            var rate = await this.usersService.VoteAsync(model.UserId, model.IsPositive);

            return this.Ok(rate);
        }
    }
}
