using AutoMapper;

namespace AdventureWorks.Business.Tests
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<DataAccess.Models.Product, Business.Model.Product>();
			CreateMap<Business.Model.Product, DataAccess.Models.Product>();
		}
	}
}
