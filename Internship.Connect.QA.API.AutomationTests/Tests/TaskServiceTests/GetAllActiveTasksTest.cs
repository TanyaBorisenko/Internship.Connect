using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Services;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests
{
    public class GetAllActiveTasksTest
    {
        [Fact]
        public async Task GetAllActiveTasks_ShouldReturn_Ok()
        {
            var taskService = new TasksService();
            IRestResponse<IList<TaskProcess>> getAllActiveTaskResponse = await taskService.GetAllActiveTasks();

            Assert.Equal(200, (int) getAllActiveTaskResponse.StatusCode);
        }
    }
}