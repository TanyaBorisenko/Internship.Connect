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
    public class GetAuthTokenBySystemIdTest:BaseTpTests
    {
        private readonly ISystemService _systemService;
        private readonly ITaskService _taskService;
        public GetAuthTokenBySystemIdTest()
        {
            _systemService = new SystemService();
            _taskService = new TasksService();
        }
        [Fact]
        public async Task GetAuthTokenBySystemId_ShouldReturn_NotFound()
        {
            TaskProcessorAuthService.GetApiAuthKey();
            
            IRestResponse<IList<TaskProcess>> getAllActiveTaskResponse = await _taskService.GetAllActiveTasks();
            Guid taskProcess = getAllActiveTaskResponse.Data.Select(d => d.Id).First();

            var response = await _systemService.GetAuthTokenBySystemId(taskProcess);

            Assert.Equal(404, (int) response.StatusCode);
        }
    }
}