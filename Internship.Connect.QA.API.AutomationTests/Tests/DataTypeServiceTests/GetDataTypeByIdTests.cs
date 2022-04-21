using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Internship.Connect.QA.API.AutomationTests.Constants;
using Internship.Connect.QA.API.AutomationTests.Entities.Factories;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.DataTypeServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.DataTypeServiceTests
{
    public class GetDataTypeByIdTests : BaseTpTests
    {
        private readonly IDataTypeService _dataTypeService;

        public GetDataTypeByIdTests()
        {
            _dataTypeService = new DataTypeService();
        }

        [Fact]
        public async Task GetDataTypeById_ValidDataTypeId_ShouldReturn_Ok()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            // Act
            var dataType = DataTypeFactory.GetDataType(DataType.Boolean, DataTypeIds.Boolean);

            var response = await _dataTypeService.GetDataTypeById<DataTypeVm>(dataType.Id);

            // Assert
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Data.Should().BeEquivalentTo(dataType);
            }
        }

        [Fact]
        public async Task GetDataTypeById_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;

            // Act
            var response = await _dataTypeService.GetDataTypeById<DataTypeVm>(dataType.Id);

            // Assert
            Assert.Equal(401, (int) getAllDataTypesResponse.StatusCode);
        }
    }
}