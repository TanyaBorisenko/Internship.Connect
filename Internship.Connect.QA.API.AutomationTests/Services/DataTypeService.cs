using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services
{
    public class DataTypeService
    {
        public async Task<IRestResponse<IList<DataType>>> GetAllDataTypes()
        {
            var restClient = new RestClient("https://connectapi-dev.azurewebsites.net");
            var restRequest = new RestRequest("/task-processor/dataTypes/all", Method.GET);
            restRequest.AddHeader("Authorization", "Bearer a7aa365d-c77f-4a98-b8bc-7627afaac372");
            restRequest.RequestFormat = DataFormat.Json;

            var response = await restClient.ExecuteAsync<IList<DataType>>(restRequest);

            return response;
        }
        
        public async Task<IRestResponse<DataType>> GetDataTypeById(Guid dataTypeId)
        {
            throw new NotImplementedException();
        }
    }
}