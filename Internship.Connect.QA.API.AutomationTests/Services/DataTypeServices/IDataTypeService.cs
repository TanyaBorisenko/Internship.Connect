using System;
using System.Threading.Tasks;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.DataTypeServices
{
    public interface IDataTypeService
    {
        Task<IRestResponse<T>> GetAllDataTypesTp<T>();

        Task<IRestResponse<T>> GetDataTypeByIdTp<T>(Guid dataTypeId);
        
        Task<IRestResponse<T>> GetAllDataTypesWeb<T>();
    }
}