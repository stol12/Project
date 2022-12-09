namespace NoLink.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NoLink.Models;
    using NoLink.Services.FirmServices;
    using System.Diagnostics;
    public class HomeController : Controller
    {
        private readonly IFirmService services;

        public HomeController(IFirmService services)
        {
            this.services = services;
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Index()
        {
            var topServices = this.services
                .FilesContent()
                .ToList();

            Console.WriteLine(topServices.Count);

            return View(topServices);  
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}