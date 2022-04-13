using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
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
            IRestResponse<IList<DataType>> getAllDataTypesResponse = await _dataTypeService.GetAllDataTypes();

            // Assert
            Assert.Equal(200, (int) getAllDataTypesResponse.StatusCode);
        }

        [Fact]
        public async Task GetAllDataTypes_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;
            
            // Act
            IRestResponse<IList<DataType>> getAllDataTypesResponse = await _dataTypeService.GetAllDataTypes();

            // Assert
            Assert.Equal(401, (int) getAllDataTypesResponse.StatusCode);
        }
    }
}