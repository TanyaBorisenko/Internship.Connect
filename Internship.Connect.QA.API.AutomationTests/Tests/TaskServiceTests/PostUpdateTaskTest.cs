using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Models.RequestModels;
using Internship.Connect.QA.API.AutomationTests.Services;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests
{
    public class PostUpdateTaskTest
    {
        [Fact]
        public async Task PostUpdateTask_ShouldReturn_Ok()
        {
            var taskService = new TasksService();
            IRestResponse<IList<TaskProcess>> getAllActiveTaskResponse = await taskService.GetAllActiveTasks();
            Guid taskProcess = getAllActiveTaskResponse.Data.Select(d => d.Id).First();

            var taskStatusRm = new TaskStatusRm()
            {
                IsSuccessful = true,
                LastExecutedDate = DateTime.Now
            };
            
            var response = await taskService.UpdateTaskLastExecutionAndStatus(taskProcess, taskStatusRm);
            
            Assert.Equal(200, (int) response.StatusCode);
        }
    }
}