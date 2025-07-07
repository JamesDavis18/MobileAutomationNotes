using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;


namespace MobileAutomationNotes
{
    [TestFixture]
    public class InputTests : AndroidTestBase
    {
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
            _driver.StartActivity("com.android.keep", ".Keep");
            _driver.FindElement(By.TagName()
            Assert.Pass();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            base.OneTimeTearDown();
        }
    }
}