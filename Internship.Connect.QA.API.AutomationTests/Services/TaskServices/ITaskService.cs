using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Models.RequestModels;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.TaskServices
{
    public interface ITaskService
    {
        Task<IRestResponse<IList<TaskProcessVm>>> GetAllActiveTasks();
        Task<IRestResponse<TaskProcessVm>> GetTaskById(Guid taskId);
        Task<IRestResponse<IList<TaskProcessVm>>> GetAllActiveTaskGroups();
        Task<IRestResponse<IList<TaskProcessVm>>> GetAllActiveIndividualTasks();
        Task<IRestResponse<TaskProcessVm>> GetATriggerForAnEntity(Guid entityId);
        Task<IRestResponse<TaskProcessVm>> UpdateTaskLastExecutionAndStatus(Guid taskId, TaskStatusRm taskStatusRm);
        Task<IRestResponse<TaskProcessVm>> DisablesWholeTaskGroupByGroupId(Guid groupId);
        Task<IRestResponse> UpdateTaskGroupLastTriggerDate(Guid groupId,DateTime? lastTriggeredDate);
    }
}