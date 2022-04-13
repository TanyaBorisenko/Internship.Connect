using System;

namespace Internship.Connect.QA.API.AutomationTests.Models.ViewModels
{
    public class TaskProcessVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SourceSystemId { get; set; }
        public Guid TargetSystemId { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset? LastExecutionDate { get; set; }
    }
}