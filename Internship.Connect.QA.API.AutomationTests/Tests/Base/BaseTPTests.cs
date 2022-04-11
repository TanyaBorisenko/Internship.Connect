using Internship.Connect.QA.API.AutomationTests.Services;

namespace Internship.Connect.QA.API.AutomationTests.Tests.Base
{
    public abstract class BaseTPTests
    {
        protected readonly ITaskProcessorAuthService TaskProcessorAuthService;
        
        protected BaseTPTests()
        {
            TaskProcessorAuthService = Services.TaskProcessorAuthService.Instance;
        }
    }
}