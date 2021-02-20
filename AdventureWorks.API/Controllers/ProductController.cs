using AdventureWorks.Business.Interface;
using AdventureWorks.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.API.Controllers
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]/[action]")]
	[ApiVersion("1")]
	[ApiVersion("2")]
	public class ProductController : ControllerBase
	{
		private readonly ILogger<ProductController> _logger;
		private readonly IProductsBusiness _productBusinessAccess;
		private readonly IMapper _mapper;
		public ProductController(ILogger<ProductController> logger, IProductsBusiness productBusinessAccess, IMapper mapper)
		{
			_logger = logger;
			_productBusinessAccess = productBusinessAccess;
			_mapper = mapper;
		}

		[HttpGet]
		[MapToApiVersion("1")]
		[ActionName("products")]
		public async Task<IEnumerable<ProductViewModel>> GetProducts()
		{
			_logger.LogInformation("GetProducts started");
			var productCollection = await _productBusinessAccess.GetProducts();
			var productViewModelCollection = _mapper.Map<IEnumerable<ProductViewModel>>(productCollection);
			_logger.LogInformation("GetProducts completed");
			return productViewModelCollection;

		}

		[HttpGet]
		[MapToApiVersion("2")]
		[ActionName("products")]
		public async Task<IActionResult> GetProductsV2()
		{
			_logger.LogInformation("GetProducts started");
			var productCollection = await _productBusinessAccess.GetProducts();
			var productViewModelCollection = _mapper.Map<IEnumerable<ProductViewModel>>(productCollection);
			_logger.LogInformation("GetProducts completed");
			return Ok(productViewModelCollection);
			//return StatusCode(StatusCodes.Status500InternalServerError);
		}

		[HttpPost]
		[ActionName("product")]
		[MapToApiVersion("1")]
		public async Task<IActionResult> SaveProducts(ProductViewModel productViewModel)
		{
			_logger.LogInformation("SaveProducts started");
			var product = _mapper.Map<Business.Models.Product>(productViewModel);
			int recordCount = await _productBusinessAccess.SaveProducts(product);
			_logger.LogInformation("SaveProducts completed");

			if (recordCount > 0)
			{
				return StatusCode(StatusCodes.Status201Created);
			}
			else
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}
