using System;
using Nunit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace MobileAutomationNotes
{
	[SetUpFixture]
	public class SetupFixture
	{
		[OneTimeSetUp]
		public void GlobalSetup()
		{
			AppDomainManagerInitializationOptions = new Appium
			// Code to run before any tests in the assembly
			Console.WriteLine("Global setup for tests.");
		}
		[OneTimeTearDown]
		public void GlobalTeardown()
		{
			// Code to run after all tests in the assembly
			Console.WriteLine("Global teardown for tests.");
		}
    }
}
