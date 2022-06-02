namespace Internship.Connect.QA.API.AutomationTests.Services
{
    public interface IWebApiService
    {
        void GetWebApiAuthKey();
        public string WebApiAuthKey { get; set; }
    }
}