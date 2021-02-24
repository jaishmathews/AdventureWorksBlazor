using AdventureWorks.ViewModel;
using AutoMapper;

namespace AdventureWorks.UIServer
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ProductViewModel, Business.Model.Product>();
			CreateMap<Business.Model.Product, ProductViewModel>();
		}

	}
}
