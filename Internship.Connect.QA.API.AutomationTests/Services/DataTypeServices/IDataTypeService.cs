using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.DataTypeServices
{
    public interface IDataTypeService
    {
        Task<IRestResponse<IList<DataType>>> GetAllDataTypes();

        Task<IRestResponse<DataType>> GetDataTypeById(Guid dataTypeId);
    }
}