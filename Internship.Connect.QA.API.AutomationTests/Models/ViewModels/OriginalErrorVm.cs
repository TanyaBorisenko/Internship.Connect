namespace Internship.Connect.QA.API.AutomationTests.Models.ViewModels
{
    public class OriginalErrorVm
    {
        public ErrorVM Errors { get; set; }

        public class ErrorVM
        {
            public string AuthorizationHeader { get; set; }
        }
    }
}