using System;
using System.Collections.Specialized;
using Nunit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace MobileAutomationNotes
{
	[TestFixture]
	public class SetupFixture : AndroidTestBase
	{
		[OneTimeSetUp]
		public void GlobalSetup()
		{
			//var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? ("http://localhost:4723/wd/hub"));
			//var driverOptions = MobileAutomationNotes.DriverManager(options);
			//AppDomainManagerInitializationOptions = new Appium
			// Code to run before any tests in the assembly
			base.OneTimeSetUp();
            Console.WriteLine("Global setup for tests.");

		}

		[OneTimeTearDown]
		public void GlobalTeardown()
		{
			base.OneTimeTearDown();
            // Code to run after all tests in the assembly
            Console.WriteLine("Global teardown for tests.");
		}
    }
}
