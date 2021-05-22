using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace NUnitTestProject1
{
    public class Tests
    {
        public static WindowsDriver<WindowsElement> Session;
        ExtentTest test;

        [SetUp]
        public void Setup()
        {
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            Session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
        }

        [Test]
        public void Test1()
        {
            try
            {
                test = ExtentReporter.CreateTest("First Test");
                Session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                Session.Manage().Window.Maximize();
                test.Info("Executing first test");
                Session.FindElementByName("Two").Click();
                Session.FindElementByName("Plus").Click();
                Session.FindElementByName("Two").Click();
                Session.FindElementByName("Equals").Click();
                var results = Session.FindElementByAccessibilityId("CalculatorResults");
                Assert.AreEqual(results.Text, "5");
                ExtentReporter.PassTest(test);
            }
            catch (Exception ex)
            {
                ExtentReporter.LogFailure(test, "Result are not as expected");
            }
        }

        [TearDown]
        public void TestCleanup()
        {
            ExtentReporter.flushreport();
            Session.Quit();
        }
    }
}