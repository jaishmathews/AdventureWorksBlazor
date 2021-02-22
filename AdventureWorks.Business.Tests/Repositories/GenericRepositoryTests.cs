using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureWorks.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.DataAccess.Models;
using AdventureWorks.Business.Tests;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Business.Repositories.Tests
{
	[TestClass()]
	public class GenericRepositoryTests : TestBase
	{
		[TestInitialize()]
		public new void Initialize()
		{
			InMemoryAdventureWorksLT2019Context.Products.Add(new Product { Name = "Product1", ProductNumber = "100", StandardCost = 1000, SellStartDate = DateTime.Now });
			InMemoryAdventureWorksLT2019Context.Products.Add(new Product { Name = "Product2", ProductNumber = "200", StandardCost = 1000, SellStartDate = DateTime.Now });
			InMemoryAdventureWorksLT2019Context.SaveChangesAsync();
		}
		[TestMethod()]
		public void GenericRepositoryTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public async Task GetAllTest()
		{
			List<Product> productList = await InMemoryAdventureWorksLT2019Context.Products.ToListAsync();
			Assert.AreEqual(2, productList.Count);
		}

		[TestMethod()]
		public void AddTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void DeleteTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void UpdateTest()
		{
			Assert.Fail();
		}
	}
}