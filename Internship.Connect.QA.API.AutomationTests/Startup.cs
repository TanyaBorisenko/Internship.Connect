using Internship.Connect.QA.API.AutomationTests.RestClientExtension;
using Internship.Connect.QA.API.AutomationTests.Services.ConnectorsServices;
using Internship.Connect.QA.API.AutomationTests.Services.DataTypeServices;
using Internship.Connect.QA.API.AutomationTests.Services.SystemServices;
using Internship.Connect.QA.API.AutomationTests.Services.TaskServices;
using Internship.Connect.QA.API.AutomationTests.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

namespace Internship.Connect.QA.API.AutomationTests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IXunitLogger, XunitLogger>();
            services.AddTransient<IExtendedRestClient, ExtendedRestClient>();
            services.AddTransient<IConnectorsService, ConnectorsService>();
            services.AddTransient<ISystemService, SystemService>();
            services.AddTransient<ITaskService, TasksService>();
            services.AddTransient<IDataTypeService, DataTypeService>();
        }

        public void Configure(ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor)
        {
            loggerFactory.AddProvider(new XunitTestOutputLoggerProvider(accessor, (s, level) =>
                level >= LogLevel.Debug &&
                level < LogLevel.None));
        }
    }
}