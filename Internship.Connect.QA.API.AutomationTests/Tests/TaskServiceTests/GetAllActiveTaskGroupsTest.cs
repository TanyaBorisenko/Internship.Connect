using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.TaskServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.TaskServiceTests
{
    public class GetAllActiveTaskGroupsTest : BaseTpTests
    {
        private readonly ITaskService _taskService;

        public GetAllActiveTaskGroupsTest()
        {
            _taskService = new TasksService();
        }

        [Fact]
        public async Task GetAllActiveTaskGroups_ShouldReturn_Ok()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            //Act
            IRestResponse<IList<TaskProcessVm>> getAllActiveTaskGroupsResponse =
                await _taskService.GetAllActiveTaskGroups();

            //Assert
            Assert.Equal(200, (int) getAllActiveTaskGroupsResponse.StatusCode);
        }

        [Fact]
        public async Task GetAllActiveTaskGroups_Unauthorized_ShouldReturn_Unauthorized()
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