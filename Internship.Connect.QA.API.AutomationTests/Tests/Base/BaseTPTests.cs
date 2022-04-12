using Internship.Connect.QA.API.AutomationTests.Services;

namespace Internship.Connect.QA.API.AutomationTests.Tests.Base
{
    public abstract class BaseTpTests
    {
        protected readonly ITaskProcessorAuthService TaskProcessorAuthService;
        
        protected BaseTpTests()
        {
            TaskProcessorAuthService = Services.TaskProcessorAuthService.Instance;
        }
    }
}