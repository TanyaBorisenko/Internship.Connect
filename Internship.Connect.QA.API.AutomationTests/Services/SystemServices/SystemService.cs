using System;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Constants;
using Internship.Connect.QA.API.AutomationTests.Models;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.SystemServices
{
    public class SystemService:BaseService,ISystemService
    {
        public async Task<IRestResponse<SystemProcess>> GetSystemById(Guid systemId)
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{SystemServiceUri.SystemById}{systemId}", Method.GET);
            var response = await RestClient.ExecuteAsync<SystemProcess>(restRequest);

            return response;
        }

        public async Task<IRestResponse<SystemProcess>> GetAuthTokenBySystemId(Guid systemId)
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{SystemServiceUri.AuthTokenBySystemId}{systemId}", Method.GET);
            var response = await RestClient.ExecuteAsync<SystemProcess>(restRequest);

            return response;
        }

        public async Task<IRestResponse<SystemProcess>> GetConnectorBySystemId(Guid systemId)
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{SystemServiceUri.ConnectorBySystemId}{systemId}", Method.GET);
            var response = await RestClient.ExecuteAsync<SystemProcess>(restRequest);

            return response;
        }
    }
}