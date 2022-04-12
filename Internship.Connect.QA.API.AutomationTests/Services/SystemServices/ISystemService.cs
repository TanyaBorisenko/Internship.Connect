using System;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.SystemServices
{
    public interface ISystemService
    {
        Task<IRestResponse<SystemProcess>> GetSystemById(Guid systemId);
        Task<IRestResponse<SystemProcess>> GetAuthTokenBySystemId(Guid systemId);
        Task<IRestResponse<SystemProcess>> GetConnectorBySystemId(Guid systemId);
    }
}