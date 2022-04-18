using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Internship.Connect.QA.API.AutomationTests.Models;
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
            IRestResponse<IList<DataTypeVm>> getAllDataTypesResponse = await _dataTypeService.GetAllDataTypes();
            Guid dataType = getAllDataTypesResponse.Data.Select(d => d.Id).First();

            var response = await _dataTypeService.GetDataTypeById<DataTypeVm>(dataType); 
            
            // Assert
            Assert.Equal(200, (int) response.StatusCode);
        }
        
        [Fact]
        public async Task GetDataTypeById_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;

            var expectedError = new OriginalErrorVm()
            {
                Errors = new OriginalErrorVm.ErrorVM() {AuthorizationHeader = "[\"Authorization data is not valid\"]"}
            };
            
            // Act
            var response = await _dataTypeService.GetDataTypeById<OriginalErrorVm>(Guid.NewGuid());

            // Assert
            response.Data.Should().BeEquivalentTo(expectedError);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}