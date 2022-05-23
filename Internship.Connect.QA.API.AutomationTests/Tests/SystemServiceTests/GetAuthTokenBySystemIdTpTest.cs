using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Internship.Connect.QA.API.AutomationTests.Models.RequestModels;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.ConnectorsServices;
using Internship.Connect.QA.API.AutomationTests.Services.SystemServices;
using Internship.Connect.QA.API.AutomationTests.Services.TaskServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.SystemServiceTests
{
    public class GetAuthTokenBySystemIdTpTest : BaseTests
    {
        private readonly ISystemService _systemService;
        private readonly ITaskService _taskService;

        public GetAuthTokenBySystemIdTpTest(ISystemService systemService, ITaskService taskService)
        {
            _systemService = systemService;
            _taskService = taskService;
        }

        [Fact]
        public async Task GetAuthTokenBySystemId_ShouldReturn_Ok()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            // Act
            IRestResponse<IList<TaskProcessVm>> allActiveTasks =
                await _taskService.GetAllActiveTasks<IList<TaskProcessVm>>();
            Guid systemId = allActiveTasks.Data.Select(s => s.SourceSystemId).First();

            var response = await _systemService.GetAuthTokenBySystemId<TaskProcessVm>(systemId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAuthTokenBySystemId_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;

            var expectedError = new OriginalErrorVm()
            {
                Errors = new OriginalErrorVm.ErrorVm() {AuthorizationHeader = "[\"Authorization data is not valid\"]"}
            };

            // Act
            var response = await _systemService.GetAuthTokenBySystemId<OriginalErrorVm>(Guid.NewGuid());

            // Assert
            using (new AssertionScope())
            {
                response.Data.Should().BeEquivalentTo(expectedError);
                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            }
        }
    }
}