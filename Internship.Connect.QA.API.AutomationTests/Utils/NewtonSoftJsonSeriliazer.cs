using Newtonsoft.Json;

namespace Internship.Connect.QA.API.AutomationTests.Utils
{
    public class NewtonSoftJsonSeriliazer
    {
        private NewtonSoftJsonSeriliazer()
        {
            
        }
        
        public static NewtonSoftJsonSeriliazer Default => new NewtonSoftJsonSeriliazer();

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None);
        }
    }
}