using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Services;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests
{
    public class GetATriggerForAnEntityTest
    {
        [Fact]
        public async Task GetTaskById_ShouldReturn_Ok()
        {
            var taskService = new TasksService();
            IRestResponse<IList<TaskProcess>> getAllActiveTaskResponse = await taskService.GetAllActiveTasks();
            Guid dataType = getAllActiveTaskResponse.Data.Select(d => d.Id).First();

            var response = await taskService.GetATriggerForAnEntity(dataType);
            
            Assert.Equal(204, (int) response.StatusCode);
        }
    }
}