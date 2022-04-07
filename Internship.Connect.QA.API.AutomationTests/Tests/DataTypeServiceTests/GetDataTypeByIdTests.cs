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
        public async Task GetDataTypesById()
        {
            var dataTypeService = new DataTypeService();
            IRestResponse<IList<DataType>> response = await dataTypeService.GetAllDataTypes();
            IList<DataType> allDataTypes = response.Data;

            var dataTypeId = from d in allDataTypes
                select d.Id;

            Assert.Equal(200, (int) response.StatusCode);
        }
    }
}