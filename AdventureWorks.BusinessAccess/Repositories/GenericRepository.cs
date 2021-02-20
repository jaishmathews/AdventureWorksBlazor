using AdventureWorks.Business.Interface;
using AdventureWorks.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Repositories
{

	public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly AdventureWorksLT2019Context _context;
		public GenericRepository(AdventureWorksLT2019Context context)
		{
			_context = context;
		}

		public async Task<T> Get(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			return await _context.Set<T>().AsNoTracking().ToListAsync();
		}

		public async Task Add(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
		}

		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
		}
	}
}
