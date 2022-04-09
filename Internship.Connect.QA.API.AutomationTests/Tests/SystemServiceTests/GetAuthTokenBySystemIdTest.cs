using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Services;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.SystemServiceTests
{
    public class GetAuthTokenBySystemIdTest
    {
        [Fact]
        public async Task GetAuthTokenBySystemId_ShouldReturn_NotFound()
        {
            var systemService = new SystemService();
            var taskService = new TasksService();
            IRestResponse<IList<TaskProcess>> getAllActiveTaskResponse = await taskService.GetAllActiveTasks();
            Guid taskProcess = getAllActiveTaskResponse.Data.Select(d => d.Id).First();

            var response = await systemService.GetAuthTokenBySystemId(taskProcess);

            Assert.Equal(404, (int) response.StatusCode);
        }
    }
}