using Microsoft.AspNetCore.Mvc;

namespace PortfolioFrontend.Controllers
{
	public class ServiceController : Controller
	{

		public ServiceController()
		{
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult WebDevelopment()
		{
			return View();
		}

		public IActionResult AppDevelopment()
		{
			return View();
		}

		public IActionResult EcommerceSolutions()
		{
			return View();
		}

		public IActionResult DatabaseManagement()
		{
			return View();
		}

		public IActionResult CloudSolutions()
		{
			return View();
		}

		public IActionResult SeoOptimization()
		{
			return View();
		}
	}
}
