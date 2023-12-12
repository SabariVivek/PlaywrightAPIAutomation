using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System.Reflection;

namespace API.Core.Reports
{
    public class ExtentManager
    {
        public static ExtentReports? ExtentReports;

        public static ExtentReports GetInstance()
        {
            if (null == ExtentReports) CreateInstance();
            return ExtentReports!;
        }

        private static void CreateInstance()
        {
            string RootDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            string WorkSpaceDirectory = RootDirectory.Split(new string[] { "\\bin", "\\Debug" }, StringSplitOptions.None)[0];
            ExtentHtmlReporter htmlReporter = new(WorkSpaceDirectory + "\\Test_Reports\\FinalReport.html");

            //------ Extent Spark Report Configuration ------//
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.DocumentTitle = "API Automation Report";
            htmlReporter.Config.ReportName = "API Automation Report";

            ExtentReports = new ExtentReports();
            ExtentReports.AttachReporter(htmlReporter);
        }
    }
}