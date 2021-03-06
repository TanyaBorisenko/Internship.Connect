using System;

namespace Internship.Connect.QA.API.AutomationTests.Models.ViewModels
{
    public class SystemProcessVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid ConnectorId { get; set; }
        public bool IsTokenConfigured { get; set; }
    }
}