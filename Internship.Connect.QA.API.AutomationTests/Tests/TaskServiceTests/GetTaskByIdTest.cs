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
    public class GetTaskByIdTest
    {
        [Fact]
        public async Task GetTaskById_ShouldReturn_Ok()
        {
           var taskService = new TasksService();
            IRestResponse<IList<TaskProcess>> getAllActiveTaskResponse = await taskService.GetAllActiveTasks();
            Guid taskProcess = getAllActiveTaskResponse.Data.Select(d => d.Id).First();

            var response = await taskService.GetTaskById(taskProcess);
            
            Assert.Equal(200, (int) response.StatusCode);
        }
    }
}