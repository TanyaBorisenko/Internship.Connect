using System;
using System.Threading.Tasks;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.DataTypeServices
{
    public interface IDataTypeService
    {
        Task<IRestResponse<T>> GetAllDataTypes<T>();

        Task<IRestResponse<T>> GetDataTypeById<T>(Guid dataTypeId);
    }
}