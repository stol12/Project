namespace NoLink.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NoLink.Services.FirmServices;

    public class ServiceController : Controller
	{
        private readonly IFirmService services;

        public ServiceController(IFirmService services)
        {
            this.services = services;
        }
        public IActionResult AllServices()
        {
            var allServices = this.services
                .AllServices()
                .ToList();

            return View(allServices);
        }
        public IActionResult Details(string id)
        {
            var model = this.services.Details(id);
            return View(model);
        }

	}
}
