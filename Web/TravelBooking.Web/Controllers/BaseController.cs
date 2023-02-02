namespace TravelBooking.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BaseController : Controller
    {
        public string ReturnUrl => this.HttpContext.Request.Path.Value + this.HttpContext.Request.QueryString.Value;
    }
}
