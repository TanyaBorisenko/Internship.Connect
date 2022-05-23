using Xunit.Abstractions;

namespace Internship.Connect.QA.API.AutomationTests.Utils
{
    public interface IXunitLogger
    {
        ITestOutputHelper OutputHelper { get; }
    }
}