using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Models.RequestModels;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.TaskServices
{
    public interface ITaskService
    {
        Task<IRestResponse<IList<TaskProcess>>> GetAllActiveTasks();
        Task<IRestResponse<TaskProcess>> GetTaskById(Guid taskId);
        Task<IRestResponse<IList<TaskProcess>>> GetAllActiveTaskGroups();
        Task<IRestResponse<IList<TaskProcess>>> GetAllActiveIndividualTasks();
        Task<IRestResponse<TaskProcess>> GetATriggerForAnEntity(Guid entityId);
        Task<IRestResponse<TaskProcess>> UpdateTaskLastExecutionAndStatus(Guid taskId, TaskStatusRm taskStatusRm);
        Task<IRestResponse<TaskProcess>> DisablesWholeTaskGroupByGroupId(Guid groupId);
        Task<IRestResponse<TaskProcess>> UpdateTaskGroupLastTriggerDate(Guid groupId,TaskStatusRm taskStatusRm);
    }
}