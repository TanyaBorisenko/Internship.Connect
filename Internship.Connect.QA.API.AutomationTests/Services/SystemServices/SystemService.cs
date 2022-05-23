using System;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Constants;
using Internship.Connect.QA.API.AutomationTests.Models.RequestModels;
using Internship.Connect.QA.API.AutomationTests.Services.Base;
using Internship.Connect.QA.API.AutomationTests.Utils;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.SystemServices
{
    public class SystemService : BaseService, ISystemService
    {
        public SystemService(IXunitLogger xunitLogger) : base(xunitLogger)
        {
        }

        public async Task<IRestResponse<T>> GetSystemById<T>(Guid systemId)
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{SystemServiceUri.SystemById}{systemId}",
                Method.GET, ConnectApi.TaskProcessor);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse<T>> GetAuthTokenBySystemId<T>(Guid systemId)
        {
            var restRequest =
                CreateRestRequest($"{Endpoints.TaskProcessor}{SystemServiceUri.AuthTokenBySystemId}{systemId}",
                    Method.GET, ConnectApi.TaskProcessor);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse<T>> GetConnectorBySystemId<T>(Guid systemId)
        {
            var restRequest =
                CreateRestRequest($"{Endpoints.TaskProcessor}{SystemServiceUri.ConnectorBySystemId}{systemId}",
                    Method.GET, ConnectApi.TaskProcessor);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse<T>> AddNewSystemWeb<T>(SystemRm systemRm)
        {
            var restRequest = CreateRestRequest(
                $"{Endpoints.WebApiService}{WebApiUri.AddNewSystem}",
                Method.POST, ConnectApi.Web, systemRm);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse<T>> GetAllSystemsWeb<T>()
        {
            var restRequest = CreateRestRequest(
                $"{Endpoints.WebApiService}{WebApiUri.AllSystems}", Method.GET, ConnectApi.Web);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse<T>> UpdateSystemWeb<T>(Guid systemId, SystemRm systemRm)
        {
            var restRequest = CreateRestRequest(
                $"{Endpoints.WebApiService}{WebApiUri.UpdateSystem}{systemId}",
                Method.PUT, ConnectApi.Web, systemRm);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse<T>> DeleteSystemWeb<T>(Guid systemId)
        {
            var restRequest = CreateRestRequest(
                $"{Endpoints.WebApiService}{WebApiUri.DeleteSystem}{systemId}",
                Method.DELETE, ConnectApi.Web);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }
    }
}