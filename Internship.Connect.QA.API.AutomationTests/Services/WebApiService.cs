namespace Internship.Connect.QA.API.AutomationTests.Services
{
    public class WebApiService : IWebApiService

    {
        private static WebApiService _webApiService = new WebApiService();
        public string WebApiAuthKey { get; set; }

        private WebApiService()
        {
        }

        public static WebApiService Instance
        {
            get
            {
                if (_webApiService is null)
                {
                    _webApiService = new WebApiService();
                }

                return _webApiService;
            }
        }

        public void GetWebApiAuthKey()
        {
            AzureDirectoryAuth azureDirectoryAuth = new AzureDirectoryAuth();
            WebApiAuthKey = azureDirectoryAuth.DirectoryAuth();
        }
    }
}