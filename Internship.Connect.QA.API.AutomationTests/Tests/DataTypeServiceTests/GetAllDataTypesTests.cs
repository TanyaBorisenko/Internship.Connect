using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Services;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.DataTypeServiceTests
{
    public class GetAllDataTypesTests
    {
        [Fact]
        public async Task GetAllDataTypes_ShouldReturn_Ok()
        {
            var dataTypeService = new DataTypeService();
            IRestResponse<IList<DataType>> getAllDataTypesResponse = await dataTypeService.GetAllDataTypes();
            
            Assert.Equal(200, (int) getAllDataTypesResponse.StatusCode);
        }
    }
}