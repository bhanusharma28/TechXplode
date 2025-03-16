using Microsoft.EntityFrameworkCore;
using PortfolioFrontend.Models;

namespace PortfolioFrontend.Data
{
	public class TechXplodeDbContext : DbContext
	{
		public TechXplodeDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
		{
			
		}

		public DbSet<Contact> Contacts { get; set; }
	}
}
