using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models.RequestModels;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.TaskServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests
{
    public class PostUpdateTaskTest : BaseTpTests
    {
        private readonly ITaskService _taskService;

        public PostUpdateTaskTest()
        {
            _taskService = new TasksService();
        }

        [Fact]
        public async Task PostUpdateTask_ShouldReturn_Ok()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            //Act
            IRestResponse<IList<TaskProcessVm>> getAllActiveTaskResponse = await _taskService.GetAllActiveTasks();
            Guid taskProcess = getAllActiveTaskResponse.Data.Select(d => d.Id).First();

            var taskStatusRm = new TaskStatusRm()
            {
                IsSuccessful = true,
                LastExecutedDate = DateTime.Now
            };

            var response = await _taskService.UpdateTaskLastExecutionAndStatus(taskProcess, taskStatusRm);

            //Assert
            Assert.Equal(200, (int) response.StatusCode);
        }

        [Fact]
        public async Task PostUpdateTask_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;

            // Act
            IRestResponse<IList<TaskProcessVm>> getAllActiveTaskResponse =
                await _taskService.GetAllActiveTasks();

            // Assert
            Assert.Equal(401, (int) getAllActiveTaskResponse.StatusCode);
        }
    }
}