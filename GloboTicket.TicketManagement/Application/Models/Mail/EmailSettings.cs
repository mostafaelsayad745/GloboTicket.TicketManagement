

namespace GloboTicket.TicketManagement.Application.Models.Mail
{
	// This class is used to store email settings like API key, from name, and from address
	// will be used to store the email settings in the appsettings.json file
	public class EmailSettings
	{
		public string ApiKey { get; set; } = string.Empty;
		public string FromName { get; set; } = string.Empty;
		public string FromAddress { get; set; } = string.Empty;
	}
}
