using System;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models.RequestModels;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.SystemServices
{
    public interface ISystemService
    {
        Task<IRestResponse<T>> GetSystemById<T>(Guid systemId);
        Task<IRestResponse<T>> GetAuthTokenBySystemId<T>(Guid systemId);
        Task<IRestResponse<T>> GetConnectorBySystemId<T>(Guid systemId);
        Task<IRestResponse<T>> AddNewSystemWeb<T>(SystemRm systemRm);
        Task<IRestResponse<T>> GetAllSystemsWeb<T>();
        Task<IRestResponse<T>> UpdateSystemWeb<T>(Guid systemId, SystemRm systemRm);
        Task<IRestResponse<T>> DeleteSystemWeb<T>(Guid systemId);
    }
}