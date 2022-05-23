using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Internship.Connect.QA.API.AutomationTests.Entities.Factories;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using Internship.Connect.QA.API.AutomationTests.Services.ConnectorsServices;
using Internship.Connect.QA.API.AutomationTests.Tests.Base;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests.Tests.ConnectorsServicesTests
{
    public class GetAllConnectorsWebTest : BaseTests
    {
        private readonly IConnectorsService _connectorsService;

        public GetAllConnectorsWebTest(IConnectorsService connectorsService)
        {
            _connectorsService = connectorsService;
        }

        [Fact]
        public async Task GetAllConnectorsWebTest_ShouldReturn_Ok()
        {
            //Arrange
            WebApiService.GetWebApiAuthKey();

            //Act
            IList<ConnectorsVm> allConnectors = ConnectorsFactory.AllConnectors();
            var response = await _connectorsService.GetAllConnectorsWeb<ConnectorsVm>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            allConnectors.Should().NotBeEmpty();
            allConnectors.Should().AllBeAssignableTo<ConnectorsVm>();
        }
        
        [Fact]
        public async Task GetAllConnectorsWebTest_Unauthorized_ShouldReturn_Unauthorized()
        {
            // Arrange
            WebApiService.WebApiAuthKey = string.Empty;

            // Act
            var response = await _connectorsService.GetAllConnectorsWeb<OriginalErrorVm>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}