using System;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.SystemServices
{
    public interface ISystemService
    {
        Task<IRestResponse<T>> GetSystemById<T>(Guid systemId);
        Task<IRestResponse<T>> GetAuthTokenBySystemId<T>(Guid systemId);
        Task<IRestResponse<T>> GetConnectorBySystemId<T>(Guid systemId);
    }
}