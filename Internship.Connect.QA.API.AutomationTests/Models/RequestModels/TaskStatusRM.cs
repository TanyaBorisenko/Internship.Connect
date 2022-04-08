using System;

namespace Internship.Connect.QA.API.AutomationTests.Models.RequestModels
{
    public class TaskStatusRM
    {
        public DateTime LastExecutedDate { get; set; }

        public bool IsSuccessful { get; set; }
    }
}