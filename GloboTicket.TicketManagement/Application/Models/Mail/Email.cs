

namespace GloboTicket.TicketManagement.Application.Models.Mail
{
	// This class is used to send emails
	// It has three properties: To, Subject, and Body
	// we didn't but this class in the domain layer because it has nothing to do with the domain it used to send emails only .
	public class Email
	{
		public string To { get; set; } = string.Empty;
		public string Subject { get; set; } = string.Empty;
		public string Body { get; set; } = string.Empty;
	}
}
