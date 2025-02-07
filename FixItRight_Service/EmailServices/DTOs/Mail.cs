using System.Net.Mail;

namespace FixItRight_Service.EmailServices.DTOs
{
	public record Mail
	{
		public MailAddress To { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }

		public Mail(string to, string subject, string body)
		{
			To = new MailAddress(to);
			Subject = subject;
			Body = body;
		}
	}
}
