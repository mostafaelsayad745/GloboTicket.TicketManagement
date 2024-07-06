

using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
	public class EventRepository : BaseRepository<Event>, IEventRepository
	{
		public EventRepository(GloboTicketDbContext context) : base(context)
		{
		}

		public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
		{
			var matches = _context.Events.Any(e => e.Name.Equals(name) && e.Date.Date.Equals(eventDate.Date));
			return Task.FromResult(matches);
		}
	}

}
