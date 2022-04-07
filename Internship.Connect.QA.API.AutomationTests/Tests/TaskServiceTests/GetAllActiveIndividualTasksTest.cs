using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Services;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests
{
    public class GetAllActiveIndividualTasksTest
    {
        [Fact]
        public async Task GetAllActiveIndividualTasks_ShouldReturn_Ok()
        {
            var taskService = new TasksService();
            IRestResponse<IList<TaskProcess>> getAllActiveIndividualTasksResponse = await taskService.GetAllActiveIndividualTasks();

            Assert.Equal(200, (int) getAllActiveIndividualTasksResponse.StatusCode);
        }
    }
}