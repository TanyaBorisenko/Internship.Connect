using System;
using Internship.Connect.QA.API.AutomationTests.Constants;
using Internship.Connect.QA.API.AutomationTests.RestClientExtension;
using Internship.Connect.QA.API.AutomationTests.Utils;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services
{
    public abstract class BaseService
    {
        protected readonly IExtendedRestClient RestClient;

        private readonly ITaskProcessorAuthService _taskProcessorAuthService;

        protected BaseService()
        {
            _taskProcessorAuthService = TaskProcessorAuthService.Instance;
            RestClient = new ExtendedRestClient(new Uri(Endpoints.ConnectUrl));
            // RestClient = new RestClient(Endpoints.ConnectUrl);
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