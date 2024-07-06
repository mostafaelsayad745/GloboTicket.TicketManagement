

using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Orders.Queries.GetOrdersForMonth
{
	// This class is used to define the query parameters for the GetPagedOrdersForMonth endpoint
	public class GetOrdersForMonthQuery : IRequest<PagedOrdersForMonthVm>
	{
		public DateTime Date { get; set; }
		public int Page { get; set; }
		public int Size { get; set; }
	}
}
