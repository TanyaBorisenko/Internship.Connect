using System;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Constants;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using RestSharp;
using System.Collections.Generic;

namespace Internship.Connect.QA.API.AutomationTests.Services.SystemServices
{
    public class SystemService:BaseService,ISystemService
    {
        public async Task<IRestResponse<T>> GetSystemById<T>(Guid systemId)
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{SystemServiceUri.SystemById}{systemId}", Method.GET);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse<T>> GetAuthTokenBySystemId<T>(Guid systemId)
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{SystemServiceUri.AuthTokenBySystemId}{systemId}", Method.GET);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse<T>> GetConnectorBySystemId<T>(Guid systemId)
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{SystemServiceUri.ConnectorBySystemId}{systemId}", Method.GET);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }
    }
}