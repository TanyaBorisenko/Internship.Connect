using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Constants;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Models.RequestModels;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.TaskServices
{
    public class TasksService : BaseService, ITaskService
    {
        public async Task<IRestResponse<T>> GetAllActiveTasks<T>()
        {
            var restRequest =
                CreateRestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.AllActiveTasks}", Method.GET);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse<T>> GetTaskById<T>(Guid taskId)
        {
            var restRequest =
                CreateRestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.TaskById}{taskId}", Method.GET);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse<T>> GetAllActiveTaskGroups<T>()
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.AllActiveTaskGroups}",
                Method.GET);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse<T>> GetAllActiveIndividualTasks<T>()
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.AllActiveIndividualTasks}",
                Method.GET);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse<T>> GetATriggerForAnEntity<T>(Guid entityId)
        {
            var restRequest = new RestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.TriggerForAnEntity}{entityId}",
                Method.GET);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse<T>> UpdateTaskLastExecutionAndStatus<T>(Guid taskId,
            TaskStatusRm taskStatusRm)
        {
            var restRequest = CreateRestRequest(
                $"{Endpoints.TaskProcessor}{TaskServiceUri.TaskLastExecutionAndStatus}{taskId}",
                Method.POST, taskStatusRm);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse<T>> DisablesWholeTaskGroupByGroupId<T>(Guid groupId)
        {
            var restRequest =
                new RestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.WholeTaskGroupByGroupId}{groupId}",
                    Method.POST);
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }

        public async Task<IRestResponse> UpdateTaskGroupLastTriggerDate(Guid groupId, DateTime? lastTriggeredDate)
        {
            var restRequest = CreateRestRequest(
                    $"{Endpoints.TaskProcessor}{TaskServiceUri.TaskGroupLastTriggerDate}{groupId}", Method.POST);
            if (lastTriggeredDate != null)
                restRequest.AddQueryParameter(Parameters.LastTriggeredDate, lastTriggeredDate.Value.ToString());
            
            var response = await RestClient.ExecuteAsync(restRequest);

            return response;
        }
        
        public async Task<IRestResponse<T>> UpdateTaskGroupLastTriggerDate<T>(Guid groupId, DateTime? lastTriggeredDate)
        {
            var restRequest = CreateRestRequest(
                $"{Endpoints.TaskProcessor}{TaskServiceUri.TaskGroupLastTriggerDate}{groupId}", Method.POST);
            if (lastTriggeredDate != null)
                restRequest.AddQueryParameter(Parameters.LastTriggeredDate, lastTriggeredDate.Value.ToString());
            
            var response = await RestClient.ExecuteAsync<T>(restRequest);

            return response;
        }
    }
}