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
    public class AddNewSystemWebTests : BaseTests
    {
        private readonly ISystemService _systemService;
        private readonly IConnectorsService _connectorsService;

        public AddNewSystemWebTests()
        {
            _systemService = new SystemService();
            _connectorsService = new ConnectorsService();
        }

        [Fact]
        public async Task AddNewSystemWebTest_ShouldReturn_Ok()
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

            //Assert
            using (new AssertionScope())
            {
                responseAdd.StatusCode.Should().Be(HttpStatusCode.OK);
                responseAdd.Data.Should().BeEquivalentTo(systemRm);
            }
        }
        
        [Fact]
        public async Task AddNewSystemWeb_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            WebApiService.WebApiAuthKey = string.Empty;

            // Act
            var response = await _connectorsService.GetAllConnectorsWeb();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        
        [Fact]
        public async Task AddNewSystemWeb_BadRequest_ShouldReturn_BadRequest()
        {
            // Arrange
            WebApiService.GetWebApiAuthKey();

            // Act
            var systemRm = new SystemRm()
            {
                Name = "name",
                Url = "1234",
                ConnectorId = Guid.NewGuid()
            };

            var responseAdd = await _systemService.AddNewSystemWeb<SystemProcessVm>(systemRm);

            // Assert
            responseAdd.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}