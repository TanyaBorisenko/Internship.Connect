using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.TaskServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.TaskServiceTests
{
    public class PostUpdateTaskGroupTest : BaseTpTests
    {
        private readonly ITaskService _taskService;

        public PostUpdateTaskGroupTest()
        {
            _taskService = new TasksService();
        }

        [Fact]
        public async Task PostUpdateTaskGroup_ShouldReturn_Ok()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            //Act
            IRestResponse<IList<TaskProcessVm>> getAllActiveTaskGroupsResponse =
                await _taskService.GetAllActiveTaskGroups();
            Guid taskProcess = getAllActiveTaskGroupsResponse.Data.Select(d => d.Id).FirstOrDefault();

            var response = await _taskService.UpdateTaskGroupLastTriggerDate(taskProcess, DateTime.Now);

            //Assert
            Assert.Equal(200, (int) response.StatusCode);
        }
        
        [Fact]
        public async Task PostUpdateTaskGroup_WithoutLastTriggeredDate_ShouldReturn_BadRequest()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            //Act
            var response = await _taskService.UpdateTaskGroupLastTriggerDate(Guid.NewGuid(), null);

            //Assert
            Assert.Equal(400, (int) response.StatusCode);
        }

        [Fact]
        public async Task PostUpdateTaskGroup_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;

            // Act
            IRestResponse<IList<TaskProcessVm>> getAllActiveTaskGroupsResponse =
                await _taskService.GetAllActiveTaskGroups();

            // Assert
            Assert.Equal(401, (int) getAllActiveTaskGroupsResponse.StatusCode);
        }
    }
}