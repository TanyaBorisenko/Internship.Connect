﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.TaskServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.TaskServiceTests
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
            IRestResponse<IList<TaskProcessVm>> getAllActiveTaskGroupsResponse =
                await _taskService.GetAllActiveTaskGroups<IList<TaskProcessVm>>();
            Guid taskProcess = getAllActiveTaskGroupsResponse.Data.Select(d => d.Id).FirstOrDefault();

            var response = await _taskService.UpdateTaskGroupLastTriggerDate(taskProcess, DateTime.Now);

            //Assert
            Assert.Equal(200, (int) response.StatusCode);
        }

        [Fact]
        public async Task PostUpdateTaskGroup_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;
        
            var expectedError = new OriginalErrorVm()
            {
                Errors = new OriginalErrorVm.ErrorVM() {AuthorizationHeader = "[\"Authorization data is not valid\"]"}
            };
            
            // Act
            var response = await _taskService.UpdateTaskGroupLastTriggerDate<OriginalErrorVm>(Guid.NewGuid(),DateTime.Now);
        
            // Assert
            response.Data.Should().BeEquivalentTo(expectedError);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}