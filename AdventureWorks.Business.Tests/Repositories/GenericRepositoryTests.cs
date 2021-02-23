using AdventureWorks.Business.Tests;
using AdventureWorks.DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Repositories.Tests
{
	[TestClass()]
	public class GenericRepositoryTests : TestBase
	{
		private Mock<GenericRepository<Product>> _genericRepositoryMock;
		[TestInitialize()]
		public new void Initialize()
		{
			_genericRepositoryMock = new Mock<GenericRepository<Product>>(InMemoryAdventureWorksLT2019Context);
		}

		[TestMethod()]
		public async Task GetTest()
		{
			Product product = await _genericRepositoryMock.Object.Get(200);
			Assert.AreEqual("Product2", product.Name);
		}

		[TestMethod()]
		public async Task GetAllTest()
		{
			var productList = await _genericRepositoryMock.Object.GetAll();
			Assert.AreEqual(2, productList.ToList().Count);
		}

		[TestMethod()]
		public async Task AddTest()
		{
			Product product = new Product { ProductId = 500, Name = "Product5", ProductNumber = "5000", StandardCost = 5000, SellStartDate = DateTime.Today, Color = null, Size = null };
			await _genericRepositoryMock.Object.Add(product);
			InMemoryAdventureWorksLT2019Context.SaveChanges();
			Assert.AreEqual(3, InMemoryAdventureWorksLT2019Context.Products.ToList().Count);
			InMemoryAdventureWorksLT2019Context.Remove(product);
			InMemoryAdventureWorksLT2019Context.SaveChanges();
		}

		[TestMethod()]
		public void DeleteTest()
		{
			Product product = InMemoryAdventureWorksLT2019Context.Products.Where(p=>p.ProductId.Equals(100)).FirstOrDefault();
			_genericRepositoryMock.Object.Delete(product);
			InMemoryAdventureWorksLT2019Context.SaveChanges();
			Assert.AreEqual(1, InMemoryAdventureWorksLT2019Context.Products.ToList().Count);
			InMemoryAdventureWorksLT2019Context.Add(product);
			InMemoryAdventureWorksLT2019Context.SaveChanges();
		}

		[TestMethod()]
		public void UpdateTest()
		{
			Product product = InMemoryAdventureWorksLT2019Context.Products.First();
			product.Name = "Product11";
			_genericRepositoryMock.Object.Update(product);
			InMemoryAdventureWorksLT2019Context.SaveChanges();
			Assert.AreEqual("Product11", InMemoryAdventureWorksLT2019Context.Products.First().Name);
		}
	}
}