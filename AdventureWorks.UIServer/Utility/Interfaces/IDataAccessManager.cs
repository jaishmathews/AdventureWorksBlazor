using System.Net.Http;
using System.Threading.Tasks;

namespace AdventureWorks.UIServer.Utility.Interfaces
{
	public interface IDataAccessManager
    {
        Task<T> GetAsync<T>(string apiRoute);
        Task<bool> PostAsync<T>(string apiRoute, T postObject);
    }
}
