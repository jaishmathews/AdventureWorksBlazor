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
			InMemoryAdventureWorksLT2019Context.Products.Add(new Product { Name = "Product1", ProductNumber = "100", StandardCost = 1000, SellStartDate = DateTime.Now });
			InMemoryAdventureWorksLT2019Context.Products.Add(new Product { Name = "Product2", ProductNumber = "200", StandardCost = 1000, SellStartDate = DateTime.Now });
			InMemoryAdventureWorksLT2019Context.SaveChangesAsync();
		}

		[TestMethod()]
		public void ProductRepositoryTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetBooksByNameTest()
		{
			
		}
	}
}