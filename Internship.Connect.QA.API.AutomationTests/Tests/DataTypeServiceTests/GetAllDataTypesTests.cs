using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.DataTypeServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.DataTypeServiceTests
{
    public class GetAllDataTypesTests : BaseTpTests
    {
         private readonly IDataTypeService _dataTypeService;
         public GetAllDataTypesTests()
         {
             _dataTypeService = new DataTypeService();
         }
        
         [Fact]
         public async Task GetAllDataTypes_ShouldReturn_Ok()
         {
             // Arrange
             TaskProcessorAuthService.GetApiAuthKey();
        
             // Act
             IRestResponse<IList<DataTypeVm>> getAllDataTypesResponse = await _dataTypeService.GetAllDataTypes<IList<DataTypeVm>>();
        
             // Assert
             Assert.Equal(200, (int) getAllDataTypesResponse.StatusCode);
         }
        
         [Fact]
         public async Task GetAllDataTypes_Unauthorized_ShouldReturn_Unauthorized()
         {
             // Arrange
             TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;
        
             var expectedError = new OriginalErrorVm()
             {
                 Errors = new OriginalErrorVm.ErrorVM() {AuthorizationHeader = "[\"Authorization data is not valid\"]"}
             };
             
             // Act
             var response = await _dataTypeService.GetAllDataTypes<OriginalErrorVm>();
        
             // Assert
             response.Data.Should().BeEquivalentTo(expectedError);
             response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}