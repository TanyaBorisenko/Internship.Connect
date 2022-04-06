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
        public async Task Test1()
        {
            var dataTypeService = new DataTypeService();
            IRestResponse<IList<DataType>> response = await dataTypeService.GetAllDataTypes();
            IList<DataType> allDataTypes = response.Data;

            Assert.Equal(200, (int) response.StatusCode);
        }
    }
}