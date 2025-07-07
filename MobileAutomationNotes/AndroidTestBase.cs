using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.ComponentModel.DataAnnotations;

namespace MobileAutomationNotes
{
    public abstract class AndroidTestBase
    {
        protected AndroidDriver _driver;
        private AppiumOptions options;

        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723/wd/hub");
            options = new AppiumOptions();
            options.PlatformName = "Android";
            options.DeviceName = "46131FDAP006EC";

            options.AddAdditionalAppiumOption("appPackage", Environment.GetEnvironmentVariable("APPIUM_APP_PATH") ?? "/path/to/your/app.apk");
            options.AddAdditionalAppiumOption("appActivity", ".BrowseActivity");
            options.AddAdditionalAppiumOption("noReset", true);

            _driver = new AndroidDriver(serverUri, options, TimeSpan.FromSeconds(180));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {

            _driver?.Dispose();
        }

    }
}
