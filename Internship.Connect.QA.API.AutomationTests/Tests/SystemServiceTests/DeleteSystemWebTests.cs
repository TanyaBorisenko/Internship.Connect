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
    public class DeleteSystemWebTests : BaseTests
    {
        private readonly ISystemService _systemService;
        private readonly IConnectorsService _connectorsService;

        public DeleteSystemWebTests(ISystemService systemService, IConnectorsService connectorsService)
        {
            _systemService = systemService;
            _connectorsService = connectorsService;
        }

        [Fact]
        public async Task DeleteSystemWebTest_ShouldReturn_Ok()
        {
            // Arrange
            WebApiService.GetWebApiAuthKey();

            //Act
            IRestResponse<IList<ConnectorsVm>> allConnectors =
                await _connectorsService.GetAllConnectorsWeb<IList<ConnectorsVm>>();
            Guid connectorId = allConnectors.Data.Select(s => s.Id).First();

            var systemRm = new SystemRm()
            {
                Name = "Tanya",
                Url = "2341",
                ConnectorId = connectorId
            };

            var responseAdd = await _systemService.AddNewSystemWeb<SystemProcessVm>(systemRm);

            Guid deleteId = responseAdd.Data.Id;

            var responseDelete = await _systemService.DeleteSystemWeb<SystemProcessVm>(deleteId);

            IRestResponse<IList<SystemProcessVm>> allUpdateSystemsWeb =
                await _systemService.GetAllSystemsWeb<IList<SystemProcessVm>>();

            //Assert
            using (new AssertionScope())
            {
                responseAdd.StatusCode.Should().Be(HttpStatusCode.OK);
                responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);
                responseDelete.Data.Should().NotBeEquivalentTo(responseAdd);
                allUpdateSystemsWeb.Data.Should().NotContainEquivalentOf(deleteId);
            }
        }

        [Fact]
        public async Task DeleteSystemWeb_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            WebApiService.WebApiAuthKey = string.Empty;

            // Act
            var response = await _connectorsService.GetAllConnectorsWeb();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task DeleteSystemWeb_NotFound_ShouldReturn_NotFound()
        {
            // Arrange
            WebApiService.GetWebApiAuthKey();

            // Act
            IRestResponse<IList<ConnectorsVm>> allConnectors =
                await _connectorsService.GetAllConnectorsWeb<IList<ConnectorsVm>>();
            Guid connectorId = allConnectors.Data.Select(s => s.Id).First();

            var systemRm = new SystemRm()
            {
                Name = "Tanya",
                Url = "2341",
                ConnectorId = connectorId
            };

            var responseAdd = await _systemService.AddNewSystemWeb<SystemProcessVm>(systemRm);

            Guid deleteId = responseAdd.Data.ConnectorId;

            var responseDelete = await _systemService.DeleteSystemWeb<SystemProcessVm>(deleteId);

            // Assert
            responseDelete.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}