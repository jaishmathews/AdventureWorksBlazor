using AdventureWorks.API.Tests;
using AdventureWorks.Business.Interface;
using AdventureWorks.Business.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.API.Controllers.Tests
{
	[TestClass()]
	public class ProductControllerTests : TestBase
	{
		Mock<IProductsBusiness> _productBusinessMock;
		Mock<ILogger<ProductController>> _loggerMock;
		Mock<IMapper> _mapperMock;

		[TestInitialize()]
		public new void Initialize()
		{
			_productBusinessMock = new Mock<IProductsBusiness>();
			_loggerMock = new Mock<ILogger<ProductController>>();
			_mapperMock = new Mock<IMapper>();
		}

		[TestMethod()]
		public async Task GetProductsTest()
		{
			ProductController productController = new ProductController(_loggerMock.Object, _productBusinessMock.Object, _mapperMock.Object);
			_productBusinessMock.Setup(p => p.GetProducts()).ReturnsAsync(ProductsList);
			List<Product> productList = await productController.GetProducts() as List<Product>;
			Assert.AreEqual(2, productList.Count());
			CollectionAssert.AllItemsAreInstancesOfType(productList, typeof(Product));
		}

		[TestMethod()]
		public async Task GetProductsV2Test()
		{
			ProductController productController = new ProductController(_loggerMock.Object, _productBusinessMock.Object, _mapperMock.Object);
			_productBusinessMock.Setup(p => p.GetProducts()).ReturnsAsync(ProductsList);
			ObjectResult objectResult = await productController.GetProductsV2() as ObjectResult;
			var productListReturned = objectResult.Value as List<Product>;
			Assert.AreEqual(2, productListReturned.Count());
			Assert.AreEqual(200, objectResult.StatusCode);
			CollectionAssert.AllItemsAreInstancesOfType(productListReturned, typeof(Product));
		}

		[TestMethod()]
		public async Task SaveProductsCreatedStatusTest()
		{
			var product = new Product();
			ProductController productController = new ProductController(_loggerMock.Object, _productBusinessMock.Object, _mapperMock.Object);
			_productBusinessMock.Setup(p => p.SaveProducts(product)).ReturnsAsync(1);
			StatusCodeResult statusCodeResult = await productController.SaveProducts(product) as StatusCodeResult;
			Assert.AreEqual(201, statusCodeResult.StatusCode);
		}

		[TestMethod()]
		public async Task SaveProductsInternalServerErrorStatusTest()
		{
			var product = new Product();
			ProductController productController = new ProductController(_loggerMock.Object, _productBusinessMock.Object, _mapperMock.Object);
			_productBusinessMock.Setup(p => p.SaveProducts(product)).ReturnsAsync(0);
			StatusCodeResult statusCodeResult = await productController.SaveProducts(product) as StatusCodeResult;
			Assert.AreEqual(500, statusCodeResult.StatusCode);
		}
	}
}