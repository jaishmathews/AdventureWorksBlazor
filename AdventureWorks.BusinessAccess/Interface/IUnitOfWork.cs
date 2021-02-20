using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Interface
{
	public interface IUnitOfWork : IDisposable
	{
		IProductRepository ProductRepository { get; }
		int Complete();
	}
}
