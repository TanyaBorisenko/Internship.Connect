using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests.RestClientExtension
{
    public interface IExtendedRestClient : IRestClient
    {
        new Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request, CancellationToken token = default);

        new Task<IRestResponse> ExecuteAsync(IRestRequest request, CancellationToken token = default);
    }
}