using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace NUnitTestProject1
{
    public class ExtentReporter
    {
        protected static ExtentTest _test;
        private static ExtentReports _extent = new ExtentReports();

        public static ExtentTest CreateTest(string TestName)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;

            var ReportPath = Path.Combine(path, "Reports", $"Automation_Report_{DateTime.Now.ToString("yyyymmddhhmmssffff", CultureInfo.CurrentCulture)}");

            var htmlReporter = new ExtentHtmlReporter(Path.Combine(ReportPath, "Extent.html"));

            _extent.AddSystemInfo("Environment", "Test");
            _extent.AddSystemInfo("User Name", "Komal");
            _extent.AttachReporter(htmlReporter);
            _test = _extent.CreateTest(TestName);
            return _test;
        }

        public static void flushreport()
        {
            _extent.Flush();
        }

        public static void PassTest(ExtentTest test)
        {
            test.Pass("Results are as expected");
        }
        public static ExtentTest CreateNode(string info)
        {
            return _test.CreateNode(info);
        }

        public static void LogFailure(ExtentTest test, string extentMessage, string screenshotPath = "", string exception = "")
        {
            //  Console.WriteLine("Failure Occured in Same File Comparison : ");
            //   childNode.Fail(extentMessage,
            //                   MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());

            test.Log(Status.Fail, "Test failed");
        }


        /*   public static string GetScreenshot(WindowsElement element1 = null, WindowsElement element2 = null)
           {
               try
               {
                   var reportPath = ExtentConfiguration.ReportPath;
                   var screenshot = Session.GetScreenshot();
                   using Bitmap screenImage = Image.FromStream(new MemoryStream(screenshot.AsByteArray)) as Bitmap, imageElement = new Bitmap(screenImage);
                   imageElement.Save("Screenshot.png");
                   using var bitmap = new Bitmap(imageElement);
                   if (element1 != null)
                   {
                       using var graphics = Graphics.FromImage(bitmap);
                       var pen = new Pen(Brushes.Red, 3);
                       var rectangle = new Rectangle(element1.Location, element1.Size);
                       if (element2 != null)
                       {
                           var rectangle2 = new Rectangle(element2.Location, element2.Size);
                           graphics.DrawRectangle(pen, rectangle2);
                       }
                       graphics.DrawRectangle(pen, rectangle);
                   }
                   var reportName = $"HighlightedImage_{GetFormatedDateTimeNow()}.png";
                   bitmap.Save(Path.Combine(reportPath, reportName));
                   return $".\\{reportName}";
               }
               catch (Exception)
               {
                   return "";
               }
           } */
    }
}

