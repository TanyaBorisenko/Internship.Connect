using System;
using System.Collections.Generic;
using System.Linq;
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
    public class GetTaskByIdTest : BaseTpTests
    {
        private readonly ITaskService _taskService;

        public GetTaskByIdTest()
        {
            _taskService = new TasksService();
        }

        [Fact]
        public async Task GetTaskById_ShouldReturn_Ok()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            //Act
            IRestResponse<IList<TaskProcessVm>> getAllActiveTaskResponse = await _taskService.GetAllActiveTasks<IList<TaskProcessVm>>();
            Guid taskProcess = getAllActiveTaskResponse.Data.Select(d => d.Id).First();

            var response = await _taskService.GetTaskById<TaskProcessVm>(taskProcess);

            //Assert
            Assert.Equal(200, (int) response.StatusCode);
        }

        [Fact]
        public async Task GetTaskById_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;
        
            var expectedError = new OriginalErrorVm()
            {
                Errors = new OriginalErrorVm.ErrorVM() {AuthorizationHeader = "[\"Authorization data is not valid\"]"}
            };
            
            // Act
            var response = await _taskService.GetTaskById<OriginalErrorVm>(Guid.NewGuid());
        
            // Assert
            response.Data.Should().BeEquivalentTo(expectedError);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}