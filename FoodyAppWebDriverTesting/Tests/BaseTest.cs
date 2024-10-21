using FoodyAppWebDriverTesting.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyAppWebDriverTesting.Tests
{
    public class BaseTest
    {
        public WebDriver driver;

        public Actions actions;

        public BasePage basePage;

        public LoginPage loginPage;

        public AddFoodPage addFoodPage;

        public EditFoodPage editFoodPage;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
            chromeOptions.AddArgument("--disable-search-engine-choice");

            driver = new ChromeDriver(chromeOptions);
            actions = new Actions(driver);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            loginPage = new LoginPage(driver);
            addFoodPage = new AddFoodPage(driver);
            basePage = new BasePage(driver);
            editFoodPage= new EditFoodPage(driver);

            loginPage.OpenPage();
            loginPage.PerformLogin("testacc", "123456");

        }

        [OneTimeTearDown]
        public void OneTimeTearDowm()
        {
            driver.Quit();
            driver.Dispose();
        }

        public string GenerateRandomFoodName()
        {
            var random = new Random();
            return "Name: " + random.Next(10000, 100000);
        }

        public string GenerateRandomFoodDescription(int length)
        {
            const string chars = "abcvfgrjgkiuktleowtsggjhk";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s=> s[random.Next(s.Length)]).ToArray());
        }
    }
}
