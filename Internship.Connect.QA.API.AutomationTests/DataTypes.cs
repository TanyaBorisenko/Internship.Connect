using Newtonsoft.Json;
using RestSharp;

namespace Internship.Connect.QA.API.AutomationTests
{
    public class DataTypes
    {
        public ListOfAllDataTypes GetDataTypes()
        {
            var restClient = new RestClient("https://connectapi-dev.azurewebsites.net");
            var restRequest = new RestRequest("/task-processor/dataTypes/all", Method.GET);
            restRequest.AddHeader("Authorization","Bearer a7aa365d-c77f-4a98-b8bc-7627afaac372");
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;

            var users = JsonConvert.DeserializeObject<ListOfAllDataTypes>(content);

            return users;
        }
    }
}