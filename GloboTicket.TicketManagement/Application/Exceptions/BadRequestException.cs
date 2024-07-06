

namespace GloboTicket.TicketManagement.Application.Exceptions
{
    // This exception is thrown when the request is not valid
	public class BadRequestException : Exception
	{
        public BadRequestException(string message) :base(message)
        {
            
        }
    }
}
