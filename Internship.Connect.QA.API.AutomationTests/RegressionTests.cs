using System;
using Xunit;

namespace Internship.Connect.QA.API.AutomationTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var dataTypes = new DataTypes();
            var response = dataTypes.GetDataTypes();
            Assert.Equal("bccc5664-0084-4782-b4d4-229196cd878d",response.id);
            Assert.Equal("System.String", response.name);
            
        }
    }
}