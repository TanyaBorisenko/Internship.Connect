using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.TaskServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests
{
    public class GetATriggerForAnEntityTest : BaseTpTests
    {
        private readonly ITaskService _taskService;

        public GetATriggerForAnEntityTest()
        {
            _taskService = new TasksService();
        }

        [Fact]
        public async Task GetATriggerForAnEntity_ShouldReturn_Ok()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            //Act
            IRestResponse<IList<TaskProcessVm>> getAllActiveTaskGroupsResponse =
                await _taskService.GetAllActiveTaskGroups();
            Guid taskProcess = getAllActiveTaskGroupsResponse.Data.Select(d => d.Id).First();

            var response = await _taskService.GetATriggerForAnEntity(taskProcess);

            //Assert
            Assert.Equal(204, (int) response.StatusCode);
        }

        [Fact]
        public async Task GetATriggerForAnEntity_Unauthorized_ShouldReturn_Unauthorized()
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