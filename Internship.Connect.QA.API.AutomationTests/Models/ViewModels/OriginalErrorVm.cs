namespace Internship.Connect.QA.API.AutomationTests.Models.ViewModels
{
    public class OriginalErrorVm
    {
        public ErrorVm Errors { get; set; }

        public class ErrorVm
        {
            public string AuthorizationHeader { get; set; }
        }
    }
}