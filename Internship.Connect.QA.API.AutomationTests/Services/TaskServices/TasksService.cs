using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Constants;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Models.RequestModels;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using Internship.Connect.QA.API.AutomationTests.Utils;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.TaskServices
{
    public class TasksService:BaseService,ITaskService
    {
        public async Task<IRestResponse<IList<TaskProcess>>> GetAllActiveTasks()
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.AllActiveTasks}", Method.GET);
            var response = await RestClient.ExecuteAsync<IList<TaskProcess>>(restRequest);

            return response;
        }

        public async Task<IRestResponse<TaskProcess>> GetTaskById(Guid taskId)
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.TaskById}{taskId}", Method.GET);
            var response = await RestClient.ExecuteAsync<TaskProcess>(restRequest);

            return response;
        }

        public async Task<IRestResponse<IList<TaskProcess>>> GetAllActiveTaskGroups()
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.AllActiveTaskGroups}", Method.GET);
            var response = await RestClient.ExecuteAsync<IList<TaskProcess>>(restRequest);

            return response;
        }

        public async Task<IRestResponse<IList<TaskProcess>>> GetAllActiveIndividualTasks()
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.AllActiveIndividualTasks}", Method.GET);
            var response = await RestClient.ExecuteAsync<IList<TaskProcess>>(restRequest);

            return response;
        }

        public async Task<IRestResponse<TaskProcess>> GetATriggerForAnEntity(Guid entityId)
        {
            var restRequest = new RestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.TriggerForAnEntity}{entityId}", Method.GET);
            var response = await RestClient.ExecuteAsync<TaskProcess>(restRequest);

            return response;
        }

        public async Task<IRestResponse<TaskProcess>> UpdateTaskLastExecutionAndStatus(Guid taskId,
            TaskStatusRm taskStatusRm)
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.TaskLastExecutionAndStatus}{taskId}",
                Method.POST);
            restRequest.AddParameter($"{Parameters.JsonEncodedUtf}", 
                NewtonSoftJsonSerializer.Default.Serialize(taskStatusRm), ParameterType.RequestBody);

            var response = await RestClient.ExecuteAsync<TaskProcess>(restRequest);

            return response;
        }
        
        public async Task<IRestResponse<TaskProcess>> DisablesWholeTaskGroupByGroupId(Guid groupId)
        {
            var restRequest =
                new RestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.WholeTaskGroupByGroupId}{groupId}", Method.POST);
            var response = await RestClient.ExecuteAsync<TaskProcess>(restRequest);

            return response;
        }

        public async Task<IRestResponse<TaskProcess>> UpdateTaskGroupLastTriggerDate(Guid groupId,TaskStatusRm taskStatusRm)
        {
            var restRequest =
                CreateRestRequest(
                    $"{Endpoints.TaskProcessor}{TaskServiceUri.TaskGroupLastTriggerDate}{groupId}",Method.POST);
            restRequest.AddParameter($"{Parameters.JsonEncodedUtf}", 
                NewtonSoftJsonSerializer.Default.Serialize(taskStatusRm), ParameterType.RequestBody);
            
            var response = await RestClient.ExecuteAsync<TaskProcess>(restRequest);

            return response;
        }
    }
}