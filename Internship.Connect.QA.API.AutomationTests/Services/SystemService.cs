using System;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services
{
    public class SystemService
    {
        public async Task<IRestResponse<SystemProcess>> GetSystemById(Guid systemId)
        {
            var restClient = new RestClient("https://connectapi-dev.azurewebsites.net");
            var restRequest = new RestRequest($"/task-processor/systems/{systemId}", Method.GET);
            restRequest.AddHeader("Authorization", "Bearer a7aa365d-c77f-4a98-b8bc-7627afaac372");
            restRequest.RequestFormat = DataFormat.Json;

            var response = await restClient.ExecuteAsync<SystemProcess>(restRequest);

            return response;
        }

        public async Task<IRestResponse<SystemProcess>> GetAuthTokenBySystemId(Guid systemId)
        {
            var restClient = new RestClient("https://connectapi-dev.azurewebsites.net");
            var restRequest = new RestRequest($"/task-processor/authTokens/{systemId}", Method.GET);
            restRequest.AddHeader("Authorization", "Bearer a7aa365d-c77f-4a98-b8bc-7627afaac372");
            restRequest.RequestFormat = DataFormat.Json;

            var response = await restClient.ExecuteAsync<SystemProcess>(restRequest);

            return response;
        }

        public async Task<IRestResponse<SystemProcess>> GetConnectorBySystemId(Guid systemId)
        {
            var restClient = new RestClient("https://connectapi-dev.azurewebsites.net");
            var restRequest = new RestRequest($"/task-processor/connectors/{systemId}", Method.GET);
            restRequest.AddHeader("Authorization", "Bearer a7aa365d-c77f-4a98-b8bc-7627afaac372");
            restRequest.RequestFormat = DataFormat.Json;

            var response = await restClient.ExecuteAsync<SystemProcess>(restRequest);

            return response;
        }
    }
}