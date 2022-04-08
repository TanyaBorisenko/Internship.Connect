using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services
{
    public class TasksService
    {
        public async Task<IRestResponse<IList<TaskProcess>>> GetAllActiveTasks()
        {
            var restClient = new RestClient("https://connectapi-dev.azurewebsites.net");
            var restRequest = new RestRequest("/task-processor/tasks/active", Method.GET);
            restRequest.AddHeader("Authorization", "Bearer a7aa365d-c77f-4a98-b8bc-7627afaac372");
            restRequest.RequestFormat = DataFormat.Json;

            var response = await restClient.ExecuteAsync<IList<TaskProcess>>(restRequest);

            return response;
        }
        
        public async Task<IRestResponse<TaskProcess>> GetTaskById(Guid taskId)
        {
            var restClient = new RestClient("https://connectapi-dev.azurewebsites.net");
            var restRequest = new RestRequest($"/task-processor/tasks/{taskId}", Method.GET);
            restRequest.AddHeader("Authorization", "Bearer a7aa365d-c77f-4a98-b8bc-7627afaac372");
            restRequest.RequestFormat = DataFormat.Json;

            var response = await restClient.ExecuteAsync<TaskProcess>(restRequest);

            return response;
        }
        
        public async Task<IRestResponse<IList<TaskProcess>>> GetAllActiveTaskGroups()
        {
            var restClient = new RestClient("https://connectapi-dev.azurewebsites.net");
            var restRequest = new RestRequest("/task-processor/tasks/groups", Method.GET);
            restRequest.AddHeader("Authorization", "Bearer a7aa365d-c77f-4a98-b8bc-7627afaac372");
            restRequest.RequestFormat = DataFormat.Json;

            var response = await restClient.ExecuteAsync<IList<TaskProcess>>(restRequest);

            return response;
        }
        
        public async Task<IRestResponse<IList<TaskProcess>>> GetAllActiveIndividualTasks()
        {
            var restClient = new RestClient("https://connectapi-dev.azurewebsites.net");
            var restRequest = new RestRequest("/task-processor/tasks/individual", Method.GET);
            restRequest.AddHeader("Authorization", "Bearer a7aa365d-c77f-4a98-b8bc-7627afaac372");
            restRequest.RequestFormat = DataFormat.Json;

            var response = await restClient.ExecuteAsync<IList<TaskProcess>>(restRequest);

            return response;
        }
        
        public async Task<IRestResponse<TaskProcess>> GetATriggerForAnEntity(Guid entityId)
        {
            var restClient = new RestClient("https://connectapi-dev.azurewebsites.net");
            var restRequest = new RestRequest($"/task-processor/tasks/trigger/{entityId}", Method.GET);
            restRequest.AddHeader("Authorization", "Bearer a7aa365d-c77f-4a98-b8bc-7627afaac372");
            restRequest.RequestFormat = DataFormat.Json;

            var response = await restClient.ExecuteAsync<TaskProcess>(restRequest);

            return response;
        }
    }
}