using AdventureWorks.Business.Interface;
using AdventureWorks.DataAccess.Models;
using System;

namespace AdventureWorks.Business.Repositories
{

	public class UnitOfWork : IUnitOfWork
	{
		private readonly AdventureWorksLT2019Context _context;
		public IProductRepository ProductRepository { get; }


		public UnitOfWork(AdventureWorksLT2019Context adventureDbContext, IProductRepository productRepository)
		{
			this._context = adventureDbContext;
			this.ProductRepository = productRepository;
		}
		public int Complete()
		{
			return _context.SaveChanges();
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				_context.Dispose();
			}
		}
	}
}
