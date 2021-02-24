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
		public async Task<IEnumerable<Model.Product>> GetProducts()
		{
			var dataProductList = await _unitOfWork.ProductRepository.GetAll();
			var businessProductList = _mapper.Map<IEnumerable<Model.Product>>(dataProductList);
			return businessProductList;
		}

		public async Task<int> SaveProducts(Model.Product product)
		{
			var dataProduct = _mapper.Map<DataAccess.Models.Product>(product);
			await _unitOfWork.ProductRepository.Add(dataProduct);
			var entries = _unitOfWork.Complete();
			return entries;
		}
	}
}
