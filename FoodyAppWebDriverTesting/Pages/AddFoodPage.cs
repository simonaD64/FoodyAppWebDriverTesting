using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyAppWebDriverTesting.Pages
{
    public class AddFoodPage : BasePage
    {
        public AddFoodPage(IWebDriver driver) : base (driver)
        {
            
        }

        public string Url = BaseUrl + "/Food/Add";

        public IWebElement FoodNameInput => driver.FindElement(By.XPath("//input[@id='name']"));
        public IWebElement DescribeFoodInput => driver.FindElement(By.XPath("//input[@id='description']"));

        public IWebElement AddPictureInput => driver.FindElement(By.XPath("//input[@id='url']"));

        public IWebElement AddButton => driver.FindElement(By.XPath("//button[@type='submit']"));

        public IWebElement MainErrorMessage => driver.FindElement(By.XPath("//li[contains(text(), 'Unable to add this food revue!')]"));
       



        public void addFood(string foodName, string description)
        {
            FoodNameInput.SendKeys(foodName);
            DescribeFoodInput.SendKeys(description);

            AddButton.Click();
        }

        public void AssertErrorMessage()
        {
            Assert.That(MainErrorMessage.Text.Trim(), Is.EqualTo("Unable to add this food revue!"), "Main error message was not expected");
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
