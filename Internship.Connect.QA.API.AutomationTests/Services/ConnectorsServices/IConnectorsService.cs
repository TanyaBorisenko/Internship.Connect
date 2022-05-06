using System.Threading.Tasks;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.ConnectorsServices
{
    public interface IConnectorsService
    {
        Task<IRestResponse<T>> GetAllConnectorsWeb<T>();
    }
}