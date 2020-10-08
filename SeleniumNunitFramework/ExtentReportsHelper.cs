using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SeleniumNunitFramework
{
    public class ExtentReportsHelper
    {
        public IWebDriver driver;
        public ExtentReports extent { get; set; }
        public ExtentV3HtmlReporter reporter { get; set; }
        public ExtentTest test { get; set; }

  public ExtentReportsHelper()
    {

            extent = new ExtentReports();
            reporter = new ExtentV3HtmlReporter(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"ExtentReports.html"));
            reporter.Config.DocumentTitle = "Test Autoamtion Execution Report";
            reporter.Config.ReportName = "Pavan Padiyala";
            reporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent.AttachReporter(reporter);
            extent.AddSystemInfo("Sys Test", "demo");
            extent.AddSystemInfo("Envi", "DEVSIT");
            extent.AddSystemInfo("MachineName", Environment.MachineName);
            extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);


        }
        //createa a test 		
        public void CreateTest(string testName)
        {
            test = extent.CreateTest(testName);
        }
        //sets test steps status to Pass 
        public void SetStepStatusPass(string stepDescription)
        {

            test.Log(Status.Pass, stepDescription);
        }
        //set test step status to warning 
        public void SetStepStatusWarning(string stepDescription)
        {

            test.Log(Status.Warning, stepDescription);
        }
        //set overall test status to Pass 
        public void SetTestStatusPass()
        {

            test.Pass("Test Executed Sucessfully!");
        }
        //set overall tests status to Fail with an error 
        public void SetTestStatusFail(string message = null)
        {

            var printMessage = "<p><b>Test FAILED!</b></p>";
            if (!string.IsNullOrEmpty(message))
            {
                printMessage += $"Message: <br>{message}<br>";
            }
            test.Fail(printMessage);
        }
        //adds exception screenshot to Extent Report 
        public void AddTestFailureScreenshot(string base64ScreenCapture)
        {

            test.AddScreenCaptureFromBase64String(base64ScreenCapture, "Screenshot on Error:");
        }
        //set steps to skip 
        public void SetTestStatusSkipped()
        {
            test.Skip("Test skipped!");
        }
        public void Close()
        {
            extent.Flush();
        }
    }

}

