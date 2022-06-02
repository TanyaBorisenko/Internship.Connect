using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Internship.Connect.QA.API.AutomationTests.Models.RequestModels;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.ConnectorsServices;
using Internship.Connect.QA.API.AutomationTests.Services.SystemServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using RestSharp;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.SystemServiceTests
{
    public class GetSystemByIdTpTest : BaseTests
    {
        private readonly ISystemService _systemService;
        private readonly IConnectorsService _connectorsService;

        public GetSystemByIdTpTest(ISystemService systemService, IConnectorsService connectorsService)
        {
            _systemService = systemService;
            _connectorsService = connectorsService;
        }

        [Fact]
        public async Task GetSystemById_ShouldReturn_Ok()
        {
            // Arrange
            WebApiService.GetWebApiAuthKey();
            TaskProcessorAuthService.GetApiAuthKey();

            // Act
            IRestResponse<IList<ConnectorsVm>> allConnectors =
                await _connectorsService.GetAllConnectorsWeb<IList<ConnectorsVm>>();
            Guid connectorId = allConnectors.Data.Select(s => s.Id).First();

            var systemRm = new SystemRm()
            {
                Name = "name",
                Url = "1234",
                ConnectorId = connectorId
            };

            var responseAdd = await _systemService.AddNewSystemWeb<SystemProcessVm>(systemRm);

            IRestResponse<IList<SystemProcessVm>> allSystems =
                await _systemService.GetAllSystemsWeb<IList<SystemProcessVm>>();
            Guid systemId = allSystems.Data.Select(s => s.Id).First();

            var response = await _systemService.GetSystemById<SystemProcessVm>(systemId);

            //Assert
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                responseAdd.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task GetSystemById_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            TaskProcessorAuthService.TaskProcessorAuthKey = string.Empty;

            var expectedError = new OriginalErrorVm()
            {
                Errors = new OriginalErrorVm.ErrorVm() {AuthorizationHeader = "[\"Authorization data is not valid\"]"}
            };

            // Act
            var response = await _systemService.GetSystemById<OriginalErrorVm>(Guid.NewGuid());

            // Assert
            using (new AssertionScope())
            {
                response.Data.Should().BeEquivalentTo(expectedError);
                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            }
        }
    }
}