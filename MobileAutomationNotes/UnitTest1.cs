using OpenQA.Selenium;

namespace MobileAutomationNotes : AndroidTestBase
{
    public class InputTests
    {
        [SetUp]
        public void Setup()
        {
            Assert.IsNotNull(_driver.Context);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}