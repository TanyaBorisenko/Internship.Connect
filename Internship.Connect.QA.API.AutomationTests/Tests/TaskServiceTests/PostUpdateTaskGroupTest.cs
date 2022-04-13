﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Models.RequestModels;
using Internship.Connect.QA.API.AutomationTests.Services.TaskServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests
{
    public class PostUpdateTaskGroupTest : BaseTpTests
    {
        private readonly ITaskService _taskService;

        public PostUpdateTaskGroupTest()
        {
            _taskService = new TasksService();
        }

        [Fact]
        public async Task PostUpdateTaskGroup_ShouldReturn_Ok()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            //Act
            IRestResponse<IList<TaskProcess>> getAllActiveTaskGroupsResponse =
                await _taskService.GetAllActiveTaskGroups();
            Guid taskProcess = getAllActiveTaskGroupsResponse.Data.Select(d => d.Id).First();

            var taskStatusRm = new TaskStatusRm()
            {
                LastTriggeredDate = DateTime.Now
            };

            var response = await _taskService.UpdateTaskGroupLastTriggerDate(taskProcess, taskStatusRm);

            //Assert
            Assert.Equal(200, (int) response.StatusCode);
        }
    }
}