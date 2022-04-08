using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Tests;
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
        public async Task<IRestResponse<TaskProcess>> UpdateTaskLastExecutionAndStatus(Guid taskId)
        {
            var restClient = new RestClient("https://connectapi-dev.azurewebsites.net");
            var restRequest = new RestRequest($"/task-processor/tasks/individual/update-task-status/{taskId}", Method.POST);
            restRequest.AddHeader("Authorization", "Bearer a7aa365d-c77f-4a98-b8bc-7627afaac372");
            restRequest.AddParameter("lastExecutedDate", "2022-03-31T14:40:26.445Z",ParameterType.GetOrPost);
            restRequest.AddParameter("isSuccessful", "true",ParameterType.GetOrPost);
            
            var response = restClient.Get<TaskProcess>(restRequest);

            return response;
        }
        
        
        public async Task<IRestResponse<TaskProcess>> DisablesWholeTaskGroupByGroupId(Guid groupId)
        {
            var restClient = new RestClient("https://connectapi-dev.azurewebsites.net");
            var restRequest = new RestRequest($"/task-processor/tasks/group/disable-failing-group/{groupId}", Method.POST);
            restRequest.AddHeader("Authorization", "Bearer a7aa365d-c77f-4a98-b8bc-7627afaac372");
            restRequest.RequestFormat = DataFormat.Json;

            var response = await restClient.ExecuteAsync<TaskProcess>(restRequest);

            return response;
        }
    }
}