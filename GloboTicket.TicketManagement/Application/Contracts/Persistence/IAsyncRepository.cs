

namespace GloboTicket.TicketManagement.Application.Contracts.Persistence
{
	// This interface is used to define the methods that will be used to interact with the database
	// This interface is generic, so it can be used with any other interfaces that inherit from it
	public interface IAsyncRepository<T> where T : class
	{
		Task<T> GetByIdAsync(Guid id);
		Task<IReadOnlyList<T>> ListAllAsync();
		Task<T> AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
	
}
