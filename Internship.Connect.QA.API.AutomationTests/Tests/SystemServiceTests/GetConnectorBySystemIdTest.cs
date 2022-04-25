using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.SystemServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.SystemServiceTests
{
    public class GetConnectorBySystemIdTest : BaseTpTests
    {
        private readonly ISystemService _systemService;

        public GetConnectorBySystemIdTest()
        {
            _systemService = new SystemService();
        }

        [Fact]
        public async Task GetConnectorBySystemId_ShouldReturn_NotFound()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            // Act
            Guid taskProcess = Guid.NewGuid();

            var response = await _systemService.GetConnectorBySystemId<SystemProcessVm>(taskProcess);

            //Assert
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
                response.Data.Should().BeEquivalentTo(taskProcess);
            }
        }

        [Fact]
        public async Task GetConnectorBySystemId_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;

            var expectedError = new OriginalErrorVm()
            {
                Errors = new OriginalErrorVm.ErrorVM() {AuthorizationHeader = "[\"Authorization data is not valid\"]"}
            };

            // Act
            var response = await _systemService.GetConnectorBySystemId<OriginalErrorVm>(Guid.NewGuid());

            // Assert
            response.Data.Should().BeEquivalentTo(expectedError);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}