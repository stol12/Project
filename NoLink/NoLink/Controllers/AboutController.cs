namespace NoLink.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NoLink.Services.UserService;
    public class AboutController : Controller
    {
        private readonly IUserService services;

        public AboutController(IUserService services)
        {
            this.services = services;
        }

        public IActionResult Index ()
        {
            return View();
        }
    }
}
