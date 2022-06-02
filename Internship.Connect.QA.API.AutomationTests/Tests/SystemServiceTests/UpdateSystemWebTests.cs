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
    public class UpdateSystemWebTests : BaseTests
    {
        private readonly ISystemService _systemService;
        private readonly IConnectorsService _connectorsService;

        public UpdateSystemWebTests(ISystemService systemService, IConnectorsService connectorsService)
        {
            _systemService = systemService;
            _connectorsService = connectorsService;
        }

        [Fact]
        public async Task UpdateSystemWebTest_ShouldReturn_Ok()
        {
            // Arrange
            WebApiService.GetWebApiAuthKey();

            //Act
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
            Guid connectorUpdateId = allSystems.Data.Select(s => s.ConnectorId).First();

            var systemRmUpdate = new SystemRm()
            {
                Name = "newName",
                Url = "98765",
                ConnectorId = connectorUpdateId
            };

            var responseUpdate = await _systemService.UpdateSystemWeb<SystemProcessVm>(systemId, systemRmUpdate);

            IRestResponse<IList<SystemProcessVm>> allUpdateSystems =
                await _systemService.GetAllSystemsWeb<IList<SystemProcessVm>>();

            //Assert
            using (new AssertionScope())
            {
                responseAdd.StatusCode.Should().Be(HttpStatusCode.OK);
                responseUpdate.StatusCode.Should().Be(HttpStatusCode.OK);
                responseUpdate.Data.Should().NotBeEquivalentTo(responseAdd);
                allUpdateSystems.Data.Should().NotBeEmpty().And.ContainEquivalentOf(systemRmUpdate);
            }
        }

        [Fact]
        public async Task UpdateSystemWeb_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            WebApiService.WebApiAuthKey = string.Empty;

            // Act
            var response = await _connectorsService.GetAllConnectorsWeb();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task UpdateSystemWeb_BadRequest_ShouldReturn_BadRequest()
        {
            // Arrange
            WebApiService.GetWebApiAuthKey();

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
            Guid connectorUpdateId = allSystems.Data.Select(s => s.Id).First();

            var systemRmUpdate = new SystemRm()
            {
                Name = "newName",
                Url = "98765",
                ConnectorId = connectorUpdateId
            };

            var responseUpdate = await _systemService.UpdateSystemWeb<SystemProcessVm>(systemId, systemRmUpdate);

            // Assert
            using (new AssertionScope())
            {
                responseAdd.StatusCode.Should().Be(HttpStatusCode.OK);
                responseUpdate.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }
    }
}