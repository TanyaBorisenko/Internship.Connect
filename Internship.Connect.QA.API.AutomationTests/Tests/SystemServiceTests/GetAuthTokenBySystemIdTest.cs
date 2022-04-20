using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.SystemServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.SystemServiceTests
{
    public class GetAuthTokenBySystemIdTest : BaseTpTests
    {
        private readonly ISystemService _systemService;

        public GetAuthTokenBySystemIdTest()
        {
            _systemService = new SystemService();
        }

        [Fact]
        public async Task GetAuthTokenBySystemId_ShouldReturn_NotFound()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            // Act
            Guid taskProcess = Guid.NewGuid();

            var response = await _systemService.GetAuthTokenBySystemId<TaskProcessVm>(taskProcess);

            //Assert
            Assert.Equal(404, (int) response.StatusCode);
        }

        [Fact]
        public async Task GetAuthTokenBySystemId_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;

            var expectedError = new OriginalErrorVm()
            {
                Errors = new OriginalErrorVm.ErrorVM() {AuthorizationHeader = "[\"Authorization data is not valid\"]"}
            };

            // Act
            var response = await _systemService.GetAuthTokenBySystemId<OriginalErrorVm>(Guid.NewGuid());

            // Assert
            response.Data.Should().BeEquivalentTo(expectedError);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}