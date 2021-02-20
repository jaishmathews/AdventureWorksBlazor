using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorks.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using AutoMapper;
using AdventureWorks.ViewModel;

namespace AdventureWorks.API
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ProductViewModel, Business.Models.Product>();
			CreateMap<Business.Models.Product, ProductViewModel>();
			CreateMap<DataAccess.Models.Product, Business.Models.Product>();
			CreateMap<Business.Models.Product, DataAccess.Models.Product>();
		}

	}
}
