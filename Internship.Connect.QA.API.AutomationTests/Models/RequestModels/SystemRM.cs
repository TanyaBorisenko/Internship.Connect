using System;

namespace Internship.Connect.QA.API.AutomationTests.Models.RequestModels
{
    public class SystemRm
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public Guid ConnectorId { get; set; }
    }
}