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
    public class WebSystemsTests : BaseTests
    {
        private readonly ISystemService _systemService;
        private readonly IConnectorsService _connectorsService;

        public WebSystemsTests()
        {
            _systemService = new SystemService();
            _connectorsService = new ConnectorsService();
        }

        [Fact]
        public async Task WebSystemTest_ShouldReturn_Ok()
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
            Guid deleteId = allUpdateSystems.Data.Select(s => s.Id).First();

            var responseDelete = await _systemService.DeleteSystemWeb<SystemProcessVm>(deleteId);

            //Assert
            using (new AssertionScope())
            {
                responseAdd.StatusCode.Should().Be(HttpStatusCode.OK);
                responseAdd.Data.Should().BeEquivalentTo(systemRm);
                allSystems.StatusCode.Should().Be(HttpStatusCode.OK);
                allSystems.Data.Should().ContainEquivalentOf(systemRm);
                responseUpdate.StatusCode.Should().Be(HttpStatusCode.OK);
                responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
    }
}