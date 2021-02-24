using AdventureWorks.Business.Interface;
using AdventureWorks.Business.Tests;
using AdventureWorks.DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Implementation.Tests
{
	[TestClass()]
	public class ProductsBusinessTests : TestBase
	{
		
		[TestMethod()]
		public async Task GetProductsTest()
		{
			var uowMock = new Mock<IUnitOfWork>();
			var productRepoMock = new Mock<IProductRepository>();
			var dbContextMock = new Mock<AdventureWorksLT2019Context>();
			var genericRepoMock = new Mock<IGenericRepository<DataAccess.Models.Product>>();

			uowMock.Setup(u => u.ProductRepository).Returns(productRepoMock.Object);
			genericRepoMock.Setup(g => g.GetAll()).ReturnsAsync(InMemoryAdventureWorksLT2019Context.Products);
			uowMock.Setup(u => u.ProductRepository.GetAll()).Returns(genericRepoMock.Object.GetAll());
			ProductsBusiness productsBusiness = new ProductsBusiness(uowMock.Object, Mapper);
			var returnedProducts = await productsBusiness.GetProducts();
			Assert.AreEqual(2, returnedProducts.Count());
			CollectionAssert.AllItemsAreInstancesOfType(returnedProducts.ToList(), typeof(Model.Product));
		}

		[TestMethod()]
		public async Task SaveProductsTest()
		{
			Model.Product businessProduct = new Model.Product { Name = "Product1", ProductNumber = "100", StandardCost = 1000, SellStartDate = DateTime.Today, Color = null, Size = null };
			DataAccess.Models.Product dataProduct = new DataAccess.Models.Product { Name = "Product1", ProductNumber = "100", StandardCost = 1000, SellStartDate = DateTime.Today, Color = null, Size = null };

			var uowMock = new Mock<IUnitOfWork>();
			var productRepoMock = new Mock<IProductRepository>();
			uowMock.Setup(u => u.ProductRepository).Returns(productRepoMock.Object);
			await uowMock.Object.ProductRepository.Add(dataProduct);
			uowMock.Setup(u => u.Complete()).Returns(1);
			ProductsBusiness productsBusiness = new ProductsBusiness(uowMock.Object, Mapper);
			var entries = await productsBusiness.SaveProducts(businessProduct);
			Assert.AreEqual(1, entries);
		}
	}
}