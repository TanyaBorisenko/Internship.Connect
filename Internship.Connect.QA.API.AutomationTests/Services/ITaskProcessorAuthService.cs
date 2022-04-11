namespace Internship.Connect.QA.API.AutomationTests.Services
{
    public interface ITaskProcessorAuthService
    {
        void GetApiAuthKey();
        
        string TaskProcessorAuthKey { get; set; }
    }
}