using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace FoodyAppWebDriverTesting.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        protected WebDriverWait wait;

        protected static readonly string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85";

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
           wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

        public IWebElement LoginNavButton => driver.FindElement(By.XPath("//a[text()='Log In']"));

        public IWebElement LearnMoreButton => driver.FindElement(By.XPath("//a[text()='Learn More']"));

        public IWebElement AddFoodButton => driver.FindElement(By.XPath("//a[text()='Add Food']"));

        public IWebElement SearchField => driver.FindElement(By.XPath("//input[@name='keyword']"));

        public IWebElement SearchButton => driver.FindElement(By.XPath("//button[@type='submit']"));

        public IWebElement LogoutNavButton => driver.FindElement(By.XPath("//a[text()='Logout']"));

    }
}
