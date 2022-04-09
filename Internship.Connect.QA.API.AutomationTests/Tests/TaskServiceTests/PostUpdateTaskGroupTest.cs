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
    public class PostUpdateTaskGroupTest
    {
        [Fact]
        public async Task PostUpdateTaskGroup_ShouldReturn_Ok()
        {
            var taskService = new TasksService();
            IRestResponse<IList<TaskProcess>> getAllActiveTaskGroupsResponse =
                await taskService.GetAllActiveTaskGroups();
            Guid taskProcess = getAllActiveTaskGroupsResponse.Data.Select(d => d.Id).First();
            
            var response = await taskService.UpdateTaskGroupLastTriggerDate(taskProcess);

            Assert.Equal(200, (int) response.StatusCode);
        }
    }
}