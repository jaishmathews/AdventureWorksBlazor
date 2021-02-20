using AdventureWorks.DataAccess.Models;
using AdventureWorks.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.API.Middleware
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
			CreateMap<DataAccess.Models.Product, ProductViewModel>();
        }
    }
}
