using System;
using System.Threading.Tasks;
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

            var response = await _systemService.GetConnectorBySystemId(taskProcess);

            //Assert
            Assert.Equal(404, (int) response.StatusCode);
        }

        [Fact]
        public async Task GetConnectorBySystemId_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;

            // Act
            Guid taskProcess = Guid.NewGuid();

            var response = await _systemService.GetConnectorBySystemId(taskProcess);

            // Assert
            Assert.Equal(401, (int) response.StatusCode);
        }
    }
}