using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.TaskServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.TaskServiceTests
{
    public class GetAllActiveTasksTest : BaseTpTests
    {
        private readonly ITaskService _taskService;

        public GetAllActiveTasksTest()
        {
            _taskService = new TasksService();
        }

        [Fact]
        public async Task GetAllActiveTasks_ShouldReturn_Ok()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            //Act
            IRestResponse<IList<TaskProcessVm>> getAllActiveTaskResponse =
                await _taskService.GetAllActiveTasks<IList<TaskProcessVm>>();

            //Assert
            using (new AssertionScope())
            {
                getAllActiveTaskResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task GetAllActiveTasks_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;

            var expectedError = new OriginalErrorVm()
            {
                Errors = new OriginalErrorVm.ErrorVM() {AuthorizationHeader = "[\"Authorization data is not valid\"]"}
            };

            // Act
            var response = await _taskService.GetAllActiveTaskGroups<OriginalErrorVm>();

            // Assert
            response.Data.Should().BeEquivalentTo(expectedError);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}