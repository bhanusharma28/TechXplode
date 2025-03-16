namespace PortfolioFrontend.Models
{
	public class Service
	{
		public int Id { get; set; }
		public string Title { get; set; }  // "Website Development"
		public string Description { get; set; }  // Service Details
		public string IconUrl { get; set; }  // Service Icon
		public int Price { get; set; }  // Optional Pricing
		public string CreatedBy { get; set; }
		public string LastUpdatedBy { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
