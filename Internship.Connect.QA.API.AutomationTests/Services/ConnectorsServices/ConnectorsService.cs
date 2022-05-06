using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Constants;
using Internship.Connect.QA.API.AutomationTests.Services.Base;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.ConnectorsServices
{
    public class ConnectorsService:BaseService, IConnectorsService 
    {
        public async Task<IRestResponse<T>> GetAllConnectorsWeb<T>()
        {
            var restRequest = CreateRestRequest($"{Endpoints.WebApiService}{WebApiUri.AllConnectors}", Method.GET,
                ConnectApi.Web);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }
    }
}