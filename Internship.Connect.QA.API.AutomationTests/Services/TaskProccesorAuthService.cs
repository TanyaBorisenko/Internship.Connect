namespace Internship.Connect.QA.API.AutomationTests.Services
{
    public class TaskProcessorAuthService : ITaskProcessorAuthService
    {
        private static TaskProcessorAuthService _taskProcessorAuthService = new TaskProcessorAuthService();
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
            TaskProcessorAuthKey = "a7aa365d-c77f-4a98-b8bc-7627afaac372";
        }

        public string TaskProcessorAuthKey { get; set; }
    }
}