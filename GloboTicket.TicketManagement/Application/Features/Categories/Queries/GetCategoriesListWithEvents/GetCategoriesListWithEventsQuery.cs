

using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
	public class GetCategoriesListWithEventsQuery :IRequest<List<CategoryEventListVM>>
	{
		// specifing if you want to include all events including previous events or only future events
        public bool IncludeHistory { get; set; }
    }
}
