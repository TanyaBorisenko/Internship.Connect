using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Internship.Connect.QA.API.AutomationTests.Constants;
using Internship.Connect.QA.API.AutomationTests.Entities.Factories;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.DataTypeServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.DataTypeServiceTests
{
    public class GetDataTypeByIdTpTests : BaseTests
    {
        private readonly IDataTypeService _dataTypeService;

        public GetDataTypeByIdTpTests(IDataTypeService dataTypeService)
        {
            _dataTypeService = dataTypeService;
        }

        [Fact]
        public async Task GetDataTypeById_ValidDataTypeId_ShouldReturn_Ok()
        {
            // Arrange
            TaskProcessorAuthService.GetApiAuthKey();

            // Act
            var dataType = DataTypeFactory.GetDataType(DataType.Boolean, DataTypeIds.Boolean);

            var response = await _dataTypeService.GetDataTypeByIdTp<DataTypeVm>(dataType.Id);

            // Assert
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Data.Should().BeEquivalentTo(dataType);
            }
        }

        [Fact]
        public async Task GetDataTypeById_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;

            var expectedError = new OriginalErrorVm()
            {
                Errors = new OriginalErrorVm.ErrorVm() {AuthorizationHeader = "[\"Authorization data is not valid\"]"}
            };

            // Act
            var response = await _dataTypeService.GetDataTypeByIdTp<OriginalErrorVm>(Guid.NewGuid());

            // Assert
            using (new AssertionScope())
            {
                response.Data.Should().BeEquivalentTo(expectedError);
                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            }
        }
    }
}