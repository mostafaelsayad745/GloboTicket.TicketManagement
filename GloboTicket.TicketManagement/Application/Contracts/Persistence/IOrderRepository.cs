using GloboTicket.TicketManagement.Domain.Entities;


namespace GloboTicket.TicketManagement.Application.Contracts.Persistence
{
	public interface IOrderRepository : IAsyncRepository<Order>
	{
		Task<List<Order>> GetPagedOrdersFormonth (DateTime date, int page, int size);
		Task<int> GetTotalCountOfOrdersForMonth(DateTime date);
	}
}
