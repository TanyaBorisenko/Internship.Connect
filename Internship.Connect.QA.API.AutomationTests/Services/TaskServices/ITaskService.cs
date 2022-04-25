using System;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models.RequestModels;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.TaskServices
{
    public interface ITaskService
    {
        Task<IRestResponse<T>> GetAllActiveTasks<T>();
        Task<IRestResponse<T>> GetTaskById<T>(Guid taskId);
        Task<IRestResponse<T>> GetAllActiveTaskGroups<T>();
        Task<IRestResponse<T>> GetAllActiveIndividualTasks<T>();
        Task<IRestResponse<T>> GetATriggerForAnEntity<T>(Guid entityId);
        Task<IRestResponse<T>> UpdateTaskLastExecutionAndStatus<T>(Guid taskId, TaskStatusRm taskStatusRm);
        Task<IRestResponse<T>> DisablesWholeTaskGroupByGroupId<T>(Guid groupId);
        Task<IRestResponse> UpdateTaskGroupLastTriggerDate(Guid groupId, DateTime? lastTriggeredDate);
        Task<IRestResponse<T>> UpdateTaskGroupLastTriggerDate<T>(Guid groupId, DateTime? lastTriggeredDate);
    }
}