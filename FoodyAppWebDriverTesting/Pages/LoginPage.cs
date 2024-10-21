using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V125.DOM;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyAppWebDriverTesting.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url = BaseUrl + "/User/Login";

        public IWebElement UsernameInputField => driver.FindElement(By.XPath("//input[@name='Username']"));

        public IWebElement PasswordInputField => driver.FindElement(By.XPath("//input[@name='Password']"));

        public IWebElement LoginButton => driver.FindElement(By.XPath("//button[contains(@class,'btn-primary')]"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void PerformLogin(string userName, string password)
        {
            UsernameInputField.Clear();
            UsernameInputField.SendKeys(userName);

            PasswordInputField.Clear();
            PasswordInputField.SendKeys(password);

            LoginButton.Click();
        }

    }
}
