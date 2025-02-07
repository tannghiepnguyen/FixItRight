using FixItRight_Service.EmailServices.DTOs;

namespace FixItRight_Service.EmailServices
{
	public interface IEmailSender
	{
		void SendEmail(Mail mail);
	}
}
