using System;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Services.SystemServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.SystemServiceTests
{
    public class GetSystemByIdTest : BaseTpTests
    {
        private readonly ISystemService _systemService;

        public GetSystemByIdTest()
        {
            _systemService = new SystemService();
        }

        [Fact]
        public async Task GetSystemById_ShouldReturn_NotFound()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            // Act
            Guid taskProcess = Guid.NewGuid();

            var response = await _systemService.GetSystemById(taskProcess);

            //Assert
            Assert.Equal(404, (int) response.StatusCode);
        }
    }
}