using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDateTime _dateTime;
        public HomeController(ILogger<HomeController> logger, IDateTime dateTime)
        {
            _logger = logger;
            _dateTime = dateTime;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = _dateTime.Now.ToString(); 
            var models = new List<Address>()
            {
               new Address(){ Name = "test",
                Street = "street",
                City = "city",
                State = "state",},
                new Address(){ Name = "test2",
                Street = "street2",
                City = "city2",
                State = "state",}
            };
            return View(models);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [Route("AboutRoute/{id:int}",Name ="about")]
        public IActionResult About(int id = 1)
        {
            ViewData["Message"] = "Your application description page.";
            ViewBag.Greeting = "Hello";
            var model = new Address()
            {
                Name = "test",
                Street = "street",
                City = "city",
                State = "state",
            };
            return View(model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
