using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Services;
using Internship.Connect.QA.API.AutomationTests.Services.SystemServices;
using Internship.Connect.QA.API.AutomationTests.Services.TaskServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.SystemServiceTests
{
    public class GetConnectorBySystemIdTest:BaseTpTests
    {
        private readonly ISystemService _systemService;
        private readonly ITaskService _taskService;
        public GetConnectorBySystemIdTest()
        {
            _systemService = new SystemService();
            _taskService = new TasksService();
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
    }
}