using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Constants;
using Internship.Connect.QA.API.AutomationTests.Services.Base;
using Internship.Connect.QA.API.AutomationTests.Utils;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.ConnectorsServices
{
    public class ConnectorsService : BaseService, IConnectorsService
    {
        public ConnectorsService(IXunitLogger xunitLogger) : base(xunitLogger)
        {
        }

        public async Task<IRestResponse<T>> GetAllConnectorsWeb<T>()
        {
            var restRequest = CreateRestRequest($"{Endpoints.WebApiService}{WebApiUri.AllConnectors}", Method.GET,
                ConnectApi.Web);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse> GetAllConnectorsWeb()
        {
            var restRequest = CreateRestRequest($"{Endpoints.WebApiService}{WebApiUri.AllConnectors}", Method.GET,
                ConnectApi.Web);
            var response = await RestClient.ExecuteAsync(restRequest);

            return response;
        }
    }
}