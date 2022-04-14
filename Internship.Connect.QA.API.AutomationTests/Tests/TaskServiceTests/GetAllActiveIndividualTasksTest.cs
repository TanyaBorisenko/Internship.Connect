using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.TaskServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.TaskServiceTests
{
    public class GetAllActiveIndividualTasksTest : BaseTpTests
    {
        private readonly ITaskService _taskService;

        public GetAllActiveIndividualTasksTest()
        {
            _taskService = new TasksService();
        }

        [Fact]
        public async Task GetAllActiveIndividualTasks_ShouldReturn_Ok()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            // Act
            IRestResponse<IList<TaskProcessVm>> getAllActiveIndividualTasksResponse =
                await _taskService.GetAllActiveIndividualTasks();

            //Assert
            Assert.Equal(200, (int) getAllActiveIndividualTasksResponse.StatusCode);
        }

        [Fact]
        public async Task GetAllActiveIndividualTasks_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;

            // Act
            IRestResponse<IList<TaskProcessVm>> getAllActiveIndividualTasksResponse =
                await _taskService.GetAllActiveIndividualTasks();

            // Assert
            Assert.Equal(401, (int) getAllActiveIndividualTasksResponse.StatusCode);
        }
    }
}