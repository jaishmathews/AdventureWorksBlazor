using AdventureWorks.Business.Implementation;
using AdventureWorks.Business.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.API.Middleware
{
    public static class Injector
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IProductsBusiness, ProductsBusiness>();
        }
    }
}
