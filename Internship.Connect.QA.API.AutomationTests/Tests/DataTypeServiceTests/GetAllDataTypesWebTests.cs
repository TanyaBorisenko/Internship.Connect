using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Internship.Connect.QA.API.AutomationTests.Entities.Factories;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.DataTypeServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.DataTypeServiceTests
{
    public class GetAllDataTypesWebTests : BaseTests
    {
        private readonly IDataTypeService _dataTypeService;

        public GetAllDataTypesWebTests()
        {
            _dataTypeService = new DataTypeService();
        }

        [Fact]
        public async Task GetAllDataTypesWeb_ShouldReturn_Ok()
        {
            // Arrange
            WebApiService.GetWebApiAuthKey();

            // Act
            IList<DataTypeVm> allDataTypes = DataTypeFactory.AllDataTypes();
            var response = await _dataTypeService.GetAllDataTypesWeb<DataTypeVm>();

            // Assert
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                allDataTypes.Should().NotBeEmpty();
                allDataTypes.Should().AllBeAssignableTo<DataTypeVm>();
            }
        }

        [Fact]
        public async Task GetAllDataTypesWeb_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            WebApiService.WebApiAuthKey = string.Empty;

            // Act
            var response = await _dataTypeService.GetAllDataTypesWeb<OriginalErrorVm>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}