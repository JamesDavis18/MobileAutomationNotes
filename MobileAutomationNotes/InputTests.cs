using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.DevTools.V136.FedCm;
using System.ComponentModel.DataAnnotations;


namespace MobileAutomationNotes
{
    [TestFixture]
    [NonParallelizable]
    public class InputTests : SetupFixture
    {
        public string appName = "com.google.android.keep";
        public string displayedPropertyName = "displayed";
        public string baseLayoutXPath = "android.widget.LinearLayout[@resource-id='com.google.android.keep:id / action_bar_root']";

        public bool CheckElementIsDisplayed(AppiumElement element)
        {
            bool isElementDisplayed = element.Displayed;
            return isElementDisplayed;
        }

        private AppiumElement? GetBaseLayout(string xPath = "//android.widget.LinearLayout[@resource]")
        {

            try
            {
                var baseLayoutElement = _driver.FindElement(By.XPath(baseLayoutXPath));
                Assert.That(baseLayoutElement.Displayed, Is.EqualTo(true), "Base app element not visible. Test cannot continue");
                if (baseLayoutElement.Displayed)
                {
                    return baseLayoutElement;
                }
                else
                {
                    TestContext.WriteLine($"Base layout element found but not displayed");
                    return null;
                }
            }
            catch (NoSuchElementException)
            {
                TestContext.WriteLine($"Base layout element not found with XPath:{xPath}");
                return null;
            }
        }


        [OneTimeSetUp]
        public override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            
        }
        
        [SetUp]
        public void Setup()
        {
            Assert.IsNotNull(_driver.Context);
            _driver.ActivateApp(appName, TimeSpan.FromSeconds(5));
            _driver.GetAppState("");
        }

        [Test, Order(1)]
        public void CreateNewNoteTest()
        {
            AppiumElement baseLayout = GetBaseLayout();
            baseLayout.Click();
            Assert.That(baseLayout.Displayed, Is.EqualTo(true), "Base app element not visible. Test cannot continue");
            string fabAddNoteId = "Create a note";
            AppiumElement addNoteFab = baseLayout.FindElement(MobileBy.AccessibilityId(fabAddNoteId));
            addNoteFab.Click();
            var fabPos = addNoteFab.Location.ToString();
            Console.WriteLine("Location:", fabPos);
            AppiumElement speedDialList = baseLayout.FindElement(By.Id("com.google.android.keep:id/speed_dial_container"));
            //string displayedProperty = speedDialList.GetAttribute("displayed");
            var isDisplayed = speedDialList.Displayed;
            Assert.IsTrue(isDisplayed);
            //AppiumElement addTextNote = speedDialList
            try
            {
                var childButton = speedDialList.FindElement(By.Id("com.google.android.keep:id/new_note_button"));
                string index = childButton.GetAttribute("index");
                int indexInt = Convert.ToInt32(index);
                //Assert.That(index, Is.EqualTo("4"), $"Button {childButton} not at the expected index ");
                Assert.AreEqual(4, indexInt, $"Button {childButton} not found at the expected index.");
                childButton.Click();
            }
            catch (NoSuchElementException)
            {

               
            }
            AppiumElement editableTitle = baseLayout.FindElement(By.Id("com.google.android.keep:id/editable_title"));
            editableTitle.Click();
            string sampleTitle = "Automation Test Note Title";
            editableTitle.SendKeys(sampleTitle);
            string actualTitle = editableTitle.GetAttribute("text");
            Assert.That(sampleTitle, Is.EqualTo(actualTitle));
            AppiumElement editableNote = baseLayout.FindElement(By.Id("com.google.android.keep:id/edit_note_text"));
            string sampleBody = "Automation test note body";
            editableNote.SendKeys(sampleBody);
            string actualBody = editableNote.GetAttribute("text");
            Assert.That(sampleBody, Is.EqualTo(actualBody));
            Assert.Pass();
        }

        [Test, Order(2)]
        public void DeleteNoteTest() 
        {
            AppiumElement baseLayout = GetBaseLayout();
            baseLayout.Click();
            Assert.That(baseLayout.Displayed, Is.EqualTo(true), "Base app element not visible. Test cannot continue");
            var noteElements = baseLayout.FindElements(By.Id("com.google.android.keep:id/browse_note_interior_content"));
            var targetNote = noteElements[0];
            targetNote.Click();
            AppiumElement title1 = baseLayout.FindElement(By.Id("com.google.android.keep:id/editable_title"));
            AppiumElement body1 = baseLayout.FindElement(By.Id("com.google.android.keep:id/edit_note_text"));
            //var isDisplayed = AppiumElement.Displayed;
            CheckElementIsDisplayed(title1);
            CheckElementIsDisplayed(body1);
            AppiumElement noteOptions = baseLayout.FindElement(MobileBy.AccessibilityId("Action"));
            noteOptions.Click();
            AppiumElement noteRecyclerView = baseLayout.FindElement(By.Id("com.google.android.keep:id/bs_popup_list"));
            AppiumElement recyclerViewDelete = baseLayout.FindElement(
                By.XPath("//android.support.v7.widget.RecyclerView[@resource-id=\"com.google.android.keep:id/bs_popup_list\"]/android.widget.LinearLayout[1]" 
                + "//android.widget.TextView[@resource-id=\"com.google.android.keep:id/menu_text\" and @text=\"Delete\"]"));
            recyclerViewDelete.Click();
            Assert.IsFalse(
                title1.Displayed && body1.Displayed,
                "Either element1 or element2 is not displayed"
            );

        }
        
        [Test, Order(3)]
        public void EditTextNoteTest()
        {
            AppiumElement baseLayout = GetBaseLayout();
            baseLayout.Click();


        }

        [Test, Order(4)]
        public void EditListNoteTest()
        {

        }

        [TearDown]
        public void TearDown()
        {
            _driver.Navigate().Back();
        }

        [OneTimeTearDown]
        public override void OneTimeTearDown()
        {
            base.OneTimeTearDown();
        }
    }
}