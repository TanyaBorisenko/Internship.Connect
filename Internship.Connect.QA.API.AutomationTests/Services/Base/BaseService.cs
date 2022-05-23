using System;
using Internship.Connect.QA.API.AutomationTests.Constants;
using Internship.Connect.QA.API.AutomationTests.RestClientExtension;
using Internship.Connect.QA.API.AutomationTests.Utils;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.Services.Base
{
    public abstract class BaseService
    {
        protected readonly IExtendedRestClient RestClient;

        private readonly ITaskProcessorAuthService _taskProcessorAuthService;
        private readonly IWebApiService _webApiService;

        protected BaseService(IXunitLogger xunitLogger)
        {
            _taskProcessorAuthService = TaskProcessorAuthService.Instance;
            RestClient = new ExtendedRestClient(new Uri(Endpoints.ConnectUrl), xunitLogger);
            _webApiService = WebApiService.Instance;
        }

        protected IRestRequest CreateRestRequest(string uri, Method method, ConnectApi connectApi,
            object payload = null)
        {
            var restRequest = new RestRequest(uri, method);
            string token = null;
            switch (connectApi)
            {
                case ConnectApi.Web:
                    token = _webApiService.WebApiAuthKey;
                    break;
                case ConnectApi.TaskProcessor:
                    token = _taskProcessorAuthService.TaskProcessorAuthKey;
                    break;
            }

            if (token is null)
            {
                throw new ArgumentException("Token is not identified");
            }

            restRequest.AddHeader(Headers.Authorization, $"Bearer {token}");

            if (payload != null)
            {
                restRequest.AddParameter(Parameters.JsonEncodedUtf, NewtonSoftJsonSerializer.Serialize(payload),
                    ParameterType.RequestBody);
            }

            return restRequest;
        }
    }

    public enum ConnectApi
    {
        TaskProcessor,
        Web
    }
}