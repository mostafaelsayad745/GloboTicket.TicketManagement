﻿

using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
	public class BaseRepository<T> : IAsyncRepository<T> where T : class
	{
		protected readonly GloboTicketDbContext _context;

		public BaseRepository(GloboTicketDbContext context)
        {
			_context = context;
		}

		public async Task<T> AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public Task DeleteAsync(T entity)
		{
			_context.Set<T>().Remove(entity);
			return _context.SaveChangesAsync();
		}

		public virtual async Task<T> GetByIdAsync(Guid id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<IReadOnlyList<T>> ListAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
