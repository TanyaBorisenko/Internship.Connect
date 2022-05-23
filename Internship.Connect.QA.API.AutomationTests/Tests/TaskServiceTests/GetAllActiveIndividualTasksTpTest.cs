﻿using System.Collections.Generic;
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
    public class GetAllActiveIndividualTasksTpTest : BaseTests
    {
        private readonly ITaskService _taskService;

        public GetAllActiveIndividualTasksTpTest(ITaskService taskService)
        {
            _taskService = taskService;
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
            getAllActiveIndividualTasksResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAllActiveIndividualTasks_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;

            var expectedError = new OriginalErrorVm()
            {
                Errors = new OriginalErrorVm.ErrorVm() {AuthorizationHeader = "[\"Authorization data is not valid\"]"}
            };

            // Act
            var response = await _taskService.GetAllActiveIndividualTasks<OriginalErrorVm>();

            // Assert
            using (new AssertionScope())
            {
                response.Data.Should().BeEquivalentTo(expectedError);
                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            }
        }
    }
}