using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace Internship.Connect.QA.API.AutomationTests.Utils
{
    public class XunitLogger:IXunitLogger
    {
        private readonly ITestOutputHelperAccessor _testOutputHelperAccessor;
        
        public XunitLogger(ITestOutputHelperAccessor testOutputHelperAccessor)
        {
            _testOutputHelperAccessor = testOutputHelperAccessor;
        }
        
        public ITestOutputHelper OutputHelper  => _testOutputHelperAccessor.Output;
    }
}