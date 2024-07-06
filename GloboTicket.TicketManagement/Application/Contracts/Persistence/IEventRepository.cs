

using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistence
{
	public interface IEventRepository : IAsyncRepository<Event>
	{
		// This method is a validation method that is used to check if the event name and date are unique
		Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
	}
}
