using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
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
                await _taskService.GetAllActiveIndividualTasks<IList<TaskProcessVm>>();

            //Assert
            Assert.Equal(200, (int) getAllActiveIndividualTasksResponse.StatusCode);
        }

        [Fact]
        public async Task GetAllActiveIndividualTasks_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;
        
            var expectedError = new OriginalErrorVm()
            {
                Errors = new OriginalErrorVm.ErrorVM() {AuthorizationHeader = "[\"Authorization data is not valid\"]"}
            };
            
            // Act
            var response = await _taskService.GetAllActiveIndividualTasks<OriginalErrorVm>();
        
            // Assert
            response.Data.Should().BeEquivalentTo(expectedError);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}