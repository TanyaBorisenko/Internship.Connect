using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Services;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.DataTypeServiceTests
{
    public class GetDataTypeByIdTests
    {
        [Fact]
        public async Task GetDataTypeById_ValidDataTypeId_ShouldReturn_Ok()
        {
            var dataTypeService = new DataTypeService();
            IRestResponse<IList<DataType>> getAllDataTypesResponse = await dataTypeService.GetAllDataTypes();
            Guid dataType = getAllDataTypesResponse.Data.Select(d => d.Id).First();

            var response = await dataTypeService.GetDataTypeById(dataType);

            Assert.Equal(200, (int) response.StatusCode);
        }
    }
}