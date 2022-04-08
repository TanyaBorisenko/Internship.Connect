using System;

namespace Internship.Connect.QA.API.AutomationTests.Models
{
    public class TaskProcess
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SourceSystemId { get; set; }
        public Guid TargetSystemId { get; set; }
        public bool IsActive { get; set; }
        public string LastExecutionDate { get; set; }
        public bool IsSuccessful { get; set; }
    }
}