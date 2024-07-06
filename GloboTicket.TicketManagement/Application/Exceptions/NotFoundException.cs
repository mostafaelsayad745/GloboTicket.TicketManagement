

namespace GloboTicket.TicketManagement.Application.Exceptions
{
	// This exception is thrown when the requested resource is not found
	// For example, when a requested event is not found in the database
	public class NotFoundException : Exception
	{
		public NotFoundException(string name, object key)
			: base($"Entity \"{name}\" ({key}) was not found.")
		{
		}
	}
}
