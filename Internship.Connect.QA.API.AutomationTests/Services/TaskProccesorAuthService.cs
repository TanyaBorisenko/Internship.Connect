using Internship.Connect.QA.API.AutomationTests.Constants;

namespace Internship.Connect.QA.API.AutomationTests.Services
{
    public class TaskProcessorAuthService : ITaskProcessorAuthService
    {
        private static TaskProcessorAuthService _taskProcessorAuthService = new TaskProcessorAuthService();
        public string TaskProcessorAuthKey { get; set; }

        private TaskProcessorAuthService()
        {
        }

        public static TaskProcessorAuthService Instance
        {
            get
            {
                if (_taskProcessorAuthService is null)
                {
                    _taskProcessorAuthService = new TaskProcessorAuthService();
                }

                return _taskProcessorAuthService;
            }
        }

        public void GetApiAuthKey()
        {
            TaskProcessorAuthKey = Endpoints.TaskProcessorAuthKey;
        }
    }
}