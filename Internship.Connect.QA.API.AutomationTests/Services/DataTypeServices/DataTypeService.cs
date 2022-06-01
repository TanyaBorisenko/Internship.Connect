using System;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Constants;
using Internship.Connect.QA.API.AutomationTests.Services.Base;
using Internship.Connect.QA.API.AutomationTests.Utils;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.DataTypeServices
{
    public class DataTypeService : BaseService, IDataTypeService
    {
        public DataTypeService(IXunitLogger xunitLogger) : base(xunitLogger)
        public async Task<IRestResponse<T>> GetAllDataTypes<T>()
        {
        }

        public async Task<IRestResponse<T>> GetAllDataTypesTp<T>()
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{DataTypesUri.AllDataTypes}", Method.GET,
                ConnectApi.TaskProcessor);
            var response = await RestClient.ExecuteAsync<T>(restRequest);
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{DataTypesUri.AllDataTypes}", Method.GET);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse<T>> GetDataTypeByIdTp<T>(Guid dataTypeId)
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{DataTypesUri.DataTypeById}{dataTypeId}",
                Method.GET, ConnectApi.TaskProcessor);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse<T>> GetAllDataTypesWeb<T>()
        {
            var restRequest = CreateRestRequest($"{Endpoints.WebApiService}{WebApiUri.AllDataTypes}", Method.GET,
                ConnectApi.Web);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }
    }
}