using AdventureWorks.Business.Interface;
using AdventureWorks.DataAccess.Models;
using System.Linq;

namespace AdventureWorks.Business.Repositories
{

	public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AdventureWorksLT2019Context context) : base(context)
        {

        }

        public Product GetProductByName(string name)
        {
            return _context.Products.Where(x => x.Name == name).FirstOrDefault();
        }

    }
}
