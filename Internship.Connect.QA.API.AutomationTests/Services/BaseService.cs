using Internship.Connect.QA.API.AutomationTests.Constants;
using Internship.Connect.QA.API.AutomationTests.Utils;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services
{
    public abstract class BaseService
    {
        protected readonly IRestClient RestClient;
        private readonly ITaskProcessorAuthService _taskProcessorAuthService;

        protected BaseService()
        {
            _taskProcessorAuthService = TaskProcessorAuthService.Instance;
            RestClient = new RestClient("https://connectapi-dev.azurewebsites.net");
        }

        protected IRestRequest CreateRestRequest(string uri, Method method, object payload = null)
        {
            var restRequest = new RestRequest(uri, method);
            restRequest.AddHeader(Headers.Authorization, $"Bearer {_taskProcessorAuthService.TaskProcessorAuthKey}");

            if (payload != null)
            {
                restRequest.AddParameter(Parameters.JsonEncodedUtf, NewtonSoftJsonSerializer.Default.Serialize(payload),
                    ParameterType.RequestBody);
            }

            return restRequest;
        }
    }
}