using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject1.src.Utils
{
    internal class ExtentReport
    {
        private ExtentReports _extent;
        private ExtentTest _test;


        [SetUp]
        public void StartReport()
        {
            var _configPath = Path.Combine(AppContext.BaseDirectory, "src", "Reports", "ExtentReport.html");
            var reporter = new ExtentSparkReporter(_configPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(reporter);
        }

        public void CreateTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        public void Log(Status status, string details)
        {
            _test.Log(status, details);
        }

        [TearDown]
        public void EndReport()
        {
            _extent.Flush();
        }
    }
}
