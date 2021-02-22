using AdventureWorks.Business.Tests;
using AdventureWorks.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Repositories.Tests
{
	[TestClass()]
	public class ProductRepositoryTests : TestBase
	{
		
		[TestInitialize()]
		public new void Initialize()
		{
			AdventureWorksLT2019Context.Products.Add(new Product { Name = "Product1", ProductNumber = "100", StandardCost = 1000, SellStartDate = DateTime.Now });
			AdventureWorksLT2019Context.Products.Add(new Product { Name = "Product2", ProductNumber = "200", StandardCost = 1000, SellStartDate = DateTime.Now });
			AdventureWorksLT2019Context.SaveChangesAsync();
		}

		[TestMethod()]
		public void ProductRepositoryTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public async Task GetBooksByNameTest()
		{
			List<Product> productList =  await  AdventureWorksLT2019Context.Products.ToListAsync();
			Assert.AreEqual(2, productList.Count);
		}
	}
}