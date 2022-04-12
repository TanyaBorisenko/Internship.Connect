using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Models.RequestModels;
using Internship.Connect.QA.API.AutomationTests.Services;
using Internship.Connect.QA.API.AutomationTests.Services.TaskServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests
{
    public class PostUpdateTaskTest:BaseTpTests
    {
        private readonly ITaskService _taskService;

        public PostUpdateTaskTest()
        {
            _taskService = new TasksService();
        }
        [Fact]
        public async Task PostUpdateTask_ShouldReturn_Ok()
        {
            TaskProcessorAuthService.GetApiAuthKey();
            
            IRestResponse<IList<TaskProcess>> getAllActiveTaskResponse = await _taskService.GetAllActiveTasks();
            Guid taskProcess = getAllActiveTaskResponse.Data.Select(d => d.Id).First();

            var taskStatusRm = new TaskStatusRm()
            {
                IsSuccessful = true,
                LastExecutedDate = DateTime.Now
            };
            
            var response = await _taskService.UpdateTaskLastExecutionAndStatus(taskProcess, taskStatusRm);
            
            Assert.Equal(200, (int) response.StatusCode);
        }
    }
}