using System;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Constants;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.DataTypeServices
{
    public class DataTypeService : BaseService, IDataTypeService
    {
        public async Task<IRestResponse<T>> GetAllDataTypes<T>()
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{DataTypesUri.AllDataTypes}", Method.GET);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse<T>> GetDataTypeById<T>(Guid dataTypeId)
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{DataTypesUri.DataTypeById}{dataTypeId}", Method.GET);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }
    }
}