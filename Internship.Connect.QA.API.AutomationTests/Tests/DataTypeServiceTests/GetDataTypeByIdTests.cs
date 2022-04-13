using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            var response = await _dataTypeService.GetDataTypeById(dataType); 
            
            // Assert
            Assert.Equal(200, (int) response.StatusCode);
        }
        
        [Fact]
        public async Task GetDataTypeById_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;
            
            // Act
            IRestResponse<IList<DataTypeVm>> getAllDataTypesResponse = await _dataTypeService.GetAllDataTypes();

            // Assert
            Assert.Equal(401, (int) getAllDataTypesResponse.StatusCode);
        }
    }
}