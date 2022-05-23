using System;
using System.Collections.Generic;
using Internship.Connect.QA.API.AutomationTests.Constants;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;

namespace Internship.Connect.QA.API.AutomationTests.Entities.Factories
{
    public static class DataTypeFactory
    {
        public static IList<DataTypeVm> AllDataTypes()
        {
            var list = new List<DataTypeVm>()
            {
                GetDataType(DataType.Boolean, DataTypeIds.Boolean),
                GetDataType(DataType.Char, DataTypeIds.Char),
                GetDataType(DataType.Decimal, DataTypeIds.Decimal),
                GetDataType(DataType.Double, DataTypeIds.Double),
                GetDataType(DataType.Int32, DataTypeIds.Int32),
                GetDataType(DataType.Single, DataTypeIds.Single),
                GetDataType(DataType.String, DataTypeIds.String),
                GetDataType(DataType.DateTime, DataTypeIds.DateTime),
            };
            return list;
        }

        public static DataTypeVm GetDataType(DataType dataType, Guid dataTypeId) => new DataTypeVm()
        {
            Name = "System." + dataType,
            Id = dataTypeId
        };
    }

    public enum DataType
    {
        String,
        Double,
        Boolean,
        Int32,
        Single,
        DateTime,
        Char,
        Decimal
    }
}