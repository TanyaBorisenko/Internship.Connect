using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Models;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.DataTypeServices
{
    public interface IDataTypeService
    {
        Task<IRestResponse<IList<DataTypeVm>>> GetAllDataTypes();

        Task<IRestResponse<T>> GetDataTypeById<T>(Guid dataTypeId);
    }
}