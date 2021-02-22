using AutoMapper;

namespace AdventureWorks.Business.Tests
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<DataAccess.Models.Product, Business.Models.Product>();
			CreateMap<Business.Models.Product, DataAccess.Models.Product>();
		}
	}
}
