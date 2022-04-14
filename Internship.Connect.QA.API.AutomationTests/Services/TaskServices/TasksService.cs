﻿using System;
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
        public async Task<IRestResponse<IList<TaskProcessVm>>> GetAllActiveTasks()
        {
            var restRequest =
                CreateRestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.AllActiveTasks}", Method.GET);
            var response = await RestClient.ExecuteAsync<IList<TaskProcessVm>>(restRequest);

            return response;
        }

        public async Task<IRestResponse<TaskProcessVm>> GetTaskById(Guid taskId)
        {
            var restRequest =
                CreateRestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.TaskById}{taskId}", Method.GET);
            var response = await RestClient.ExecuteAsync<TaskProcessVm>(restRequest);

            return response;
        }

        public async Task<IRestResponse<IList<TaskProcessVm>>> GetAllActiveTaskGroups()
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.AllActiveTaskGroups}",
                Method.GET);
            var response = await RestClient.ExecuteAsync<IList<TaskProcessVm>>(restRequest);

            return response;
        }

        public async Task<IRestResponse<IList<TaskProcessVm>>> GetAllActiveIndividualTasks()
        {
            var restRequest = CreateRestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.AllActiveIndividualTasks}",
                Method.GET);
            var response = await RestClient.ExecuteAsync<IList<TaskProcessVm>>(restRequest);

            return response;
        }

        public async Task<IRestResponse<TaskProcessVm>> GetATriggerForAnEntity(Guid entityId)
        {
            var restRequest = new RestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.TriggerForAnEntity}{entityId}",
                Method.GET);
            var response = await RestClient.ExecuteAsync<TaskProcessVm>(restRequest);

            return response;
        }

        public async Task<IRestResponse<TaskProcessVm>> UpdateTaskLastExecutionAndStatus(Guid taskId,
            TaskStatusRm taskStatusRm)
        {
            var restRequest = CreateRestRequest(
                $"{Endpoints.TaskProcessor}{TaskServiceUri.TaskLastExecutionAndStatus}{taskId}",
                Method.POST, taskStatusRm);
            var response = await RestClient.ExecuteAsync<TaskProcessVm>(restRequest);

            return response;
        }

        public async Task<IRestResponse<TaskProcessVm>> DisablesWholeTaskGroupByGroupId(Guid groupId)
        {
            var restRequest =
                new RestRequest($"{Endpoints.TaskProcessor}{TaskServiceUri.WholeTaskGroupByGroupId}{groupId}",
                    Method.POST);
            var response = await RestClient.ExecuteAsync<TaskProcessVm>(restRequest);

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
    }
}