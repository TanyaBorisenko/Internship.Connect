using Internship.Connect.QA.API.AutomationTests.Services;

namespace Internship.Connect.QA.API.AutomationTests.Tests.Base
{
    public abstract class BaseTests
    {
        protected readonly ITaskProcessorAuthService TaskProcessorAuthService;
        protected readonly IWebApiService WebApiService;

        protected BaseTests()
        {
            TaskProcessorAuthService = Services.TaskProcessorAuthService.Instance;
            WebApiService = Services.WebApiService.Instance;
        }
    }
}