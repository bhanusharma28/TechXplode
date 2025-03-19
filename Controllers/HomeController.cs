using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortfolioFrontend.Data;
using PortfolioFrontend.Migrations;
using PortfolioFrontend.Models;
using PortfolioFrontend.Service;

namespace PortfolioFrontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly TechXplodeDbContext techXplodeDbContext;
		private readonly EmailService emailService;

		public HomeController(ILogger<HomeController> logger, TechXplodeDbContext techXplodeDbContext, EmailService emailService)
        {
            _logger = logger;
			this.techXplodeDbContext = techXplodeDbContext;
			this.emailService = emailService;
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
					SendEmail(contact.Email, contact.Name);
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

		public void SendEmail(string email, string username)
		{
			string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}"; // Replace with your actual domain
			string logoUrl = $"{baseUrl}/TechXplodeWebLogoNew.png";
			string body = $@"
				<html>
				<head>
					<style>
						body {{ font-family: Arial, sans-serif; color: #333; }}
						.container {{ padding: 20px; border: 1px solid #ddd; border-radius: 8px; max-width: 600px; }}
						.header {{ font-size: 18px; font-weight: bold; margin-bottom: 10px; }}
						.message {{ font-size: 16px; line-height: 1.5; }}
						.footer {{ margin-top: 20px; font-size: 14px; color: #555; }}
					</style>
				</head>
				<body>
					<div class='container'>
						<div class='header'>Hello {username},</div>
						<p class='message'>
							Thank you for reaching out to us! We have received your message and will get back to you as soon as possible.
							Our team typically responds within 24-48 hours. If your request is urgent, feel free to reach out to us directly.
						</p>
						<p class='message'>
							We appreciate your patience and look forward to assisting you!
						</p>
						<div class='footer'>
							<p>Thanks & Regards,</p>
							<p><strong>TechXplode</strong></p>
							<img src='{logoUrl}' alt='Company Logo' style=""width: 200px; height: 60px; object-fit: cover;"" />
						</div>
					</div>
				</body>
				</html>";
			emailService.SendEmail(email, "Thank You for Reaching Out – We’ll Get Back to You Soon!", body);			
		}
	}
}
