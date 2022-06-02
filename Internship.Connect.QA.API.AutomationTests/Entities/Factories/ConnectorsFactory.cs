using System;
using System.Collections.Generic;
using Internship.Connect.QA.API.AutomationTests.Constants;
using Internship.Connect.QA.API.AutomationTests.Models.ViewModels;

namespace Internship.Connect.QA.API.AutomationTests.Entities.Factories
{
    public static class ConnectorsFactory
    {
        public static IList<ConnectorsVm> AllConnectors()
        {
            var list = new List<ConnectorsVm>()
            {
                GetAllConnectors(Connectors.Bloomberg, AllConnectorsIds.Bloomberg),
                GetAllConnectors(Connectors.Salesforce, AllConnectorsIds.Salesforce),
                GetAllConnectors(Connectors.CsvFile, AllConnectorsIds.CsvFile),
                GetAllConnectors(Connectors.XlsxFile, AllConnectorsIds.XlsxFile),
                GetAllConnectors(Connectors.DealCloud, AllConnectorsIds.DealCloud),
                GetAllConnectors(Connectors.EFront, AllConnectorsIds.EFront),
                GetAllConnectors(Connectors.MicrosoftSql, AllConnectorsIds.MicrosoftSql)
            };
            return list;
        }

        public static ConnectorsVm GetAllConnectors(Connectors connectors, Guid connectorsId) => new ConnectorsVm()
        {
            Name = connectors + "Connector",
            Id = connectorsId
        };

        public enum Connectors
        {
            Bloomberg,
            Salesforce,
            XlsxFile,
            CsvFile,
            MicrosoftSql,
            DealCloud,
            EFront
        }
    }
}