using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Services;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests
{
    public class GetAllActiveTaskGroupsTest
    {
        [Fact]
        public async Task GetAllActiveTaskGroups_ShouldReturn_Ok()
        {
            var taskService = new TasksService();
            IRestResponse<IList<TaskProcess>> getAllActiveTaskGroupsResponse = await taskService.GetAllActiveTaskGroups();

            Assert.Equal(200, (int) getAllActiveTaskGroupsResponse.StatusCode);
        }
    }
}