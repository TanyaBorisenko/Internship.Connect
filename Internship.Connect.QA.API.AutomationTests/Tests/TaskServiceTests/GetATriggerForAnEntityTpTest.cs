using System;
using System.Collections.Generic;
using System.Linq;
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
    public class GetATriggerForAnEntityTpTest : BaseTests
    {
        private readonly ITaskService _taskService;

        public GetATriggerForAnEntityTpTest(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [Fact]
        public async Task GetATriggerForAnEntity_ShouldReturn_Ok()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            //Act
            IRestResponse<IList<TaskProcessVm>> getAllActiveTaskGroupsResponse =
                await _taskService.GetAllActiveTaskGroups<IList<TaskProcessVm>>();
            Guid taskProcess = getAllActiveTaskGroupsResponse.Data.Select(d => d.Id).First();

            var response = await _taskService.GetATriggerForAnEntity<IList<TaskProcessVm>>(taskProcess);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetATriggerForAnEntity_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;

            var expectedError = new OriginalErrorVm()
            {
                Errors = new OriginalErrorVm.ErrorVm() {AuthorizationHeader = "[\"Authorization data is not valid\"]"}
            };

            // Act
            var response = await _taskService.GetATriggerForAnEntity<OriginalErrorVm>(Guid.NewGuid());

            // Assert
            using (new AssertionScope())
            {
                response.Data.Should().BeEquivalentTo(expectedError);
                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            }
        }
    }
}