using System.Net.Mail;
using System.Net;

namespace PortfolioFrontend.Service
{
	public class EmailService
	{
		private readonly IConfiguration _config;

		public EmailService(IConfiguration config)
		{
			_config = config;
		}

		public void SendEmail(string toEmail, string subject, string body)
		{
			string host = _config["SmtpSettings:Host"];
			int port = int.Parse(_config["SmtpSettings:Port"]);
			string username = _config["SmtpSettings:Username"];
			string password = _config["SmtpSettings:Password"];
			bool enableSSL = bool.Parse(_config["SmtpSettings:EnableSSL"]);

			var smtpClient = new SmtpClient(host)
			{
				Port = port,
				Credentials = new NetworkCredential(username, password),
				EnableSsl = enableSSL,
				Timeout = 20000
			};

			var mailMessage = new MailMessage
			{
				From = new MailAddress(username),
				Subject = subject,
				Body = body,
				IsBodyHtml = true
			};

			mailMessage.To.Add(toEmail);
			smtpClient.Send(mailMessage);
		}
	}
}
