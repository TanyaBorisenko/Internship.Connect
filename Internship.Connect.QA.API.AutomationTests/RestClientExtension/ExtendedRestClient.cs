using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Internship.Connect.QA.API.AutomationTests.Utils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Xunit.Abstractions;

namespace Internship.Connect.QA.API.AutomationTests.RestClientExtension
{
    public class ExtendedRestClient : RestClient, IExtendedRestClient
    {
        private readonly ILogger _logger;
        private readonly IXunitLogger _xunitLogger;

        public ExtendedRestClient(Uri uri, IXunitLogger xunitLogger) : base(uri)
        public ExtendedRestClient(Uri uri) : base(uri)

        {
            _xunitLogger = xunitLogger;
            _logger = xunitLogger.OutputHelper.ToLogger<ExtendedRestClient>();
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
            _logger.LogInformation($"{request.Method} request to: {request.Resource}");

            var body = request.Parameters
                .FirstOrDefault(p => p.Type == ParameterType.RequestBody)?.Value;
            if (request.Body != null) _logger.LogInformation($"body: {FormatRequestBody(body.ToString())}");
        }

        private void LogResponse(IRestResponse response)
        {
            if (response.ErrorException != null)
            {
                _logger.LogError($"Error retrieving response. Error message is {response.ErrorException.Message}");
            }

            _logger.LogInformation($"Request finished with status code: {response.StatusCode}");
            if (!string.IsNullOrEmpty(response.Content))
            {
                _logger.LogInformation(FormatRequestBody(response.Content));
            }
        }

        private string FormatRequestBody(string body)
        {
            try
            {
                return JToken.Parse(body).ToString(Formatting.Indented);
            }
            catch (JsonReaderException e)
            {
                _logger.LogError($"Wrong body format, the error is: {e.Message}");

                return string.Empty;
            }
        }
    }
}