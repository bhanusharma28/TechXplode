using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortfolioFrontend.Data;
using PortfolioFrontend.Migrations;
using PortfolioFrontend.Models;

namespace PortfolioFrontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly TechXplodeDbContext techXplodeDbContext;

		public HomeController(ILogger<HomeController> logger, TechXplodeDbContext techXplodeDbContext)
        {
            _logger = logger;
			this.techXplodeDbContext = techXplodeDbContext;
		}

        public IActionResult Index()
        {
            return View();
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

        [HttpGet]
		public IActionResult Contact()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Contact(Contact contact)
		{
			if (ModelState.IsValid)
			{
				await techXplodeDbContext.Contacts.AddAsync(contact);
				var info = await techXplodeDbContext.SaveChangesAsync();
				if (info > 0)
				{
					TempData["SuccessMessage"] = "Thank you for contacting us! We will get back to you shortly.";
				}
				else
				{
					TempData["ErrorMessage"] = "Something went wrong. Please try again later.";
				}
			}
			else
			{
				TempData["ErrorMessage"] = "Please fill in all fields correctly.";
			}

			return RedirectToAction("Contact");
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Blogs()
		{
			return View();
		}

		public IActionResult Testimonial()
		{
			return View();
		}

		public IActionResult IndustriesWeServe()
		{
			return View();
		}
	}
}
