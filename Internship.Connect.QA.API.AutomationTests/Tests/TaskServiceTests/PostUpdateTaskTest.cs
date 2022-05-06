using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Internship.Connect.QA.API.AutomationTests.Models.RequestModels;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.TaskServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.TaskServiceTests
{
    public class PostUpdateTaskTest : BaseTests
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
            IRestResponse<IList<TaskProcessVm>> getAllActiveTaskResponse =
                await _taskService.GetAllActiveTasks<IList<TaskProcessVm>>();
            Guid taskProcess = getAllActiveTaskResponse.Data.Select(d => d.Id).First();

            var taskStatusRm = new TaskStatusRm()
            {
                IsSuccessful = true,
                LastExecutedDate = DateTime.Now
            };

            var response =
                await _taskService.UpdateTaskLastExecutionAndStatus<TaskProcessVm>(taskProcess, taskStatusRm);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task PostUpdateTask_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;

            var taskStatusRm = new TaskStatusRm();
            var expectedError = new OriginalErrorVm()
            {
                Errors = new OriginalErrorVm.ErrorVm() {AuthorizationHeader = "[\"Authorization data is not valid\"]"}
            };

            // Act
            var response =
                await _taskService.UpdateTaskLastExecutionAndStatus<OriginalErrorVm>(Guid.NewGuid(), taskStatusRm);

            // Assert
            using (new AssertionScope())
            {
                response.Data.Should().BeEquivalentTo(expectedError);
                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            }
        }
    }
}