using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Services;
using Internship.Connect.QA.API.AutomationTests.Services.TaskServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests
{
    public class GetAllActiveTasksTest:BaseTpTests
    {
        private readonly ITaskService _taskService;

        public GetAllActiveTasksTest()
        {
            _taskService = new TasksService();
        }
        [Fact]
        public async Task GetAllActiveTasks_ShouldReturn_Ok()
        {
            TaskProcessorAuthService.GetApiAuthKey();
            
            IRestResponse<IList<TaskProcess>> getAllActiveTaskResponse = await _taskService.GetAllActiveTasks();

            Assert.Equal(200, (int) getAllActiveTaskResponse.StatusCode);
        }
    }
}