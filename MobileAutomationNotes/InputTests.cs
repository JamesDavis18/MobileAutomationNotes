using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;


namespace MobileAutomationNotes
{
    [TestFixture]
    public class InputTests : SetupFixture
    {
        public string appName = "com.google.android.keep";

        [OneTimeSetUp]
        public virtual void OneTimeSetup()
        {
            base.OneTimeSetUp();
            
        }
        
        [SetUp]
        public void Setup()
        {
            Assert.IsNotNull(_driver.Context);
        }

        [Test]
        public void CreateNewNoteTest()
        {
            _driver.ActivateApp(appName, TimeSpan.FromSeconds(5));
            _driver.GetAppState("");
            AppiumElement baseLayout = _driver.FindElement(By.XPath("//android.widget.LinearLayout[@resource-id='com.google.android.keep:id / action_bar_root']"));
            baseLayout.Click();
            _driver.FindElement(By.TagName("body")).Text;
            Assert.Pass();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            base.OneTimeTearDown();
        }
    }
}