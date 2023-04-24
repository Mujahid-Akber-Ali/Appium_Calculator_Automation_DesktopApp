using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace Appium_Calculator_Automation
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Calculator_Automation()
        {
            System.Diagnostics.Process.Start
              (@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");

            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", @"Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            var driver = new WindowsDriver<WindowsElement>
                (new Uri("http://127.0.0.1:4723"), options);

            driver.FindElementByName("Five").Click();
            driver.FindElementByName("Plus").Click();
            driver.FindElementByName("Seven").Click();
            driver.FindElementByName("Equals").Click();

            var calculatorResult = driver.FindElementByAccessibilityId("CalculatorResults").Text.Replace("Display is", string.Empty).Trim();
            Assert.AreEqual("12", calculatorResult);

            driver.CloseApp();
        }
    }
}
