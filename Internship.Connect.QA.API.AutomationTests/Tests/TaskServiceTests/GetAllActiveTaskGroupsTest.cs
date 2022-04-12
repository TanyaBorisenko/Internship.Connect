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
    public class GetAllActiveTaskGroupsTest:BaseTpTests
    {
        private readonly ITaskService _taskService;

        public GetAllActiveTaskGroupsTest()
        {
            _taskService = new TasksService();
        }
        [Fact]
        public async Task GetAllActiveTaskGroups_ShouldReturn_Ok()
        {
            TaskProcessorAuthService.GetApiAuthKey();
            
            IRestResponse<IList<TaskProcess>> getAllActiveTaskGroupsResponse = await _taskService.GetAllActiveTaskGroups();

            Assert.Equal(200, (int) getAllActiveTaskGroupsResponse.StatusCode);
        }
    }
}