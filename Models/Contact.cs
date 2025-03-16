using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PortfolioFrontend.Models
{
	public class Contact
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		public string Name { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Message { get; set; }
	}
}
