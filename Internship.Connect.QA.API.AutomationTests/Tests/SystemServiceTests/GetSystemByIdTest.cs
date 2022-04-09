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
    public class GetSystemByIdTest
    {
        [Fact]
        public async Task GetSystemById_ShouldReturn_NotFound()
        {
            var systemService = new SystemService();
            var taskService = new TasksService();
            IRestResponse<IList<TaskProcess>> getAllActiveTaskResponse = await taskService.GetAllActiveTasks();
            Guid taskProcess = getAllActiveTaskResponse.Data.Select(d => d.Id).First();

            var response = await systemService.GetSystemById(taskProcess);

            Assert.Equal(404, (int) response.StatusCode);
        }
    }
}