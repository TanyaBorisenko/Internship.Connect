using System;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.SystemServices
{
    public interface ISystemService
    {
        Task<IRestResponse<SystemProcessVm>> GetSystemById(Guid systemId);
        Task<IRestResponse<SystemProcessVm>> GetAuthTokenBySystemId(Guid systemId);
        Task<IRestResponse<SystemProcessVm>> GetConnectorBySystemId(Guid systemId);
    }
}