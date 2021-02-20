using AdventureWorks.Business.Interface;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Implementation
{
	public class ProductsBusiness : IProductsBusiness
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ProductsBusiness(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<IEnumerable<Models.Product>> GetProducts()
		{
			var products = _mapper.Map<IEnumerable<Models.Product>>(await _unitOfWork.ProductRepository.GetAll());
			return products;
		}

		public async Task<int> SaveProducts(Models.Product product)
		{
			var dataProduct = _mapper.Map<DataAccess.Models.Product>(product);
			await _unitOfWork.ProductRepository.Add(dataProduct);
			var entries = _unitOfWork.Complete();
			return entries;
		}
	}
}
