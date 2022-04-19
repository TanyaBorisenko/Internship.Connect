using System;
using System.Threading;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Utils;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.RestClientExtension
{
    public class ExtendedRestClient : RestClient, IExtendedRestClient
    { 
        private ILogger<ExtendedRestClient> Logger => LoggerBuilder.GetLogger<ExtendedRestClient>();

       public ExtendedRestClient(Uri uri) : base(uri)
        {
        }

        public new async Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request, CancellationToken token = default)
        {
            LogRequest(request);
            var response = await base.ExecuteAsync<T>(request, token);
            LogResponse(response);

            return response;
        }

        public new async Task<IRestResponse> ExecuteAsync(IRestRequest request, CancellationToken token = default)
        {
            LogRequest(request);
            var response = await base.ExecuteAsync(request, token);
            LogResponse(response);

            return response;
        }

        private void LogRequest(IRestRequest request)
        {
            Logger.LogInformation($"{request.Method} request to {request.Resource}");
            if (request.Body != null) Logger.LogInformation($"body: {request.Body}");
        }

        private void LogResponse(IRestResponse response)
        {
            if (response.ErrorException != null)
            {
                Logger.LogError($"Error retrieving response. Error message is {response.ErrorException.Message}");
            }
            
            Logger.LogInformation($"Request finished with status code: {response.StatusCode}");
            if (!string.IsNullOrEmpty(response.Content))
            {
                Logger.LogInformation($"{response.Content}");
            }
        }
    }
}