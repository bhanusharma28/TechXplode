namespace PortfolioFrontend.Models
{
	public class SignIn
	{
		public string Email { get; set; }  // Unique Email
		public string PasswordHash { get; set; }  // Hashed Password
	}
}
