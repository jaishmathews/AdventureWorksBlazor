using AdventureWorks.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Interface
{
    public interface IProductsBusiness
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<int> SaveProducts(Product product);
    }
}
