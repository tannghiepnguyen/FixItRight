using FixItRight_Service.EmailServices.DTOs;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace FixItRight_Service.EmailServices
{
	public class EmailSender : IEmailSender
	{
		private readonly IConfiguration configuration;

		public EmailSender(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
		public void SendEmail(Mail mail)
		{
			var mailMessage = CreateMailMessage(mail);
			Send(mailMessage);
		}

		private MailMessage CreateMailMessage(Mail mail)
		{
			var mailMessage = new MailMessage();
			mailMessage.From = new MailAddress(configuration.GetSection("Email").Value!);
			mailMessage.Subject = mail.Subject;
			mailMessage.To.Add(mail.To);
			mailMessage.Body = mail.Body;
			mailMessage.IsBodyHtml = true;
			return mailMessage;
		}

		private void Send(MailMessage mailMessage)
		{
			using (var smtpClient = new SmtpClient("smtp.gmail.com"))
			{
				smtpClient.Port = 587;
				smtpClient.Credentials = new NetworkCredential(configuration.GetSection("Email").Value!, configuration.GetSection("Password").Value!);
				smtpClient.EnableSsl = true;
				smtpClient.Send(mailMessage);
			}
		}
	}
}
