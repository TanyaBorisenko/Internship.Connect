using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
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
            TaskProcessorAuthService.GetApiAuthKey();
            
            IRestResponse<IList<DataType>> getAllDataTypesResponse = await _dataTypeService.GetAllDataTypes();
            Guid dataType = getAllDataTypesResponse.Data.Select(d => d.Id).First();

            var response = await _dataTypeService.GetDataTypeById(dataType);

            Assert.Equal(200, (int) response.StatusCode);
        }
    }
}