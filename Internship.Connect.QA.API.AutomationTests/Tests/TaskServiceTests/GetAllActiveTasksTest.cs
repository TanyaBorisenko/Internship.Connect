﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.TaskServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.TaskServiceTests
{
    public class GetAllActiveTasksTest : BaseTpTests
    {
        private readonly ITaskService _taskService;

        public GetAllActiveTasksTest()
        {
            _taskService = new TasksService();
        }

        [Fact]
        public async Task GetAllActiveTasks_ShouldReturn_Ok()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            //Act
            IRestResponse<IList<TaskProcessVm>> getAllActiveTaskResponse = await _taskService.GetAllActiveTasks();

            //Assert
            Assert.Equal(200, (int) getAllActiveTaskResponse.StatusCode);
        }

        [Fact]
        public async Task GetAllActiveTasks_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;

            // Act
            IRestResponse<IList<TaskProcessVm>> getAllActiveTaskResponse =
                await _taskService.GetAllActiveTasks();

            // Assert
            Assert.Equal(401, (int) getAllActiveTaskResponse.StatusCode);
        }
    }
}