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
    public class GetAllDataTypesTests : BaseTests
    {
        private readonly IDataTypeService _dataTypeService;

        public GetAllDataTypesTests()
        {
            _dataTypeService = new DataTypeService();
        }

        [Fact]
        public async Task GetAllDataTypesTp_ShouldReturn_Ok()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            // Act
            IList<DataTypeVm> allDataTypes = DataTypeFactory.AllDataTypes();
            var response = await _dataTypeService.GetAllDataTypesTp<DataTypeVm>();

            // Assert
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                allDataTypes.Should().NotBeEmpty();
                allDataTypes.Should().AllBeAssignableTo<DataTypeVm>();
            }
        }

        [Fact]
        public async Task GetAllDataTypes_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;

            var expectedError = new OriginalErrorVm()
            {
                Errors = new OriginalErrorVm.ErrorVm() {AuthorizationHeader = "[\"Authorization data is not valid\"]"}
            };

            // Act
            var response = await _dataTypeService.GetAllDataTypesTp<OriginalErrorVm>();

            // Assert
            using (new AssertionScope())
            {
                response.Data.Should().BeEquivalentTo(expectedError);
                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            }
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
    }
}