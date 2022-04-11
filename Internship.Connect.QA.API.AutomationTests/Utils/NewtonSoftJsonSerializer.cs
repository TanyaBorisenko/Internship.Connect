using Newtonsoft.Json;

namespace Internship.Connect.QA.API.AutomationTests.Utils
{
    public class NewtonSoftJsonSerializer
    {
        private NewtonSoftJsonSerializer()
        {
        }

        public static NewtonSoftJsonSerializer Default => new NewtonSoftJsonSerializer();

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None);
        }
    }
}