using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyAppWebDriverTesting.Pages
{
    public class EditFoodPage : BasePage
    {
        public EditFoodPage(IWebDriver driver) : base (driver)
        {
           
        }

          public string Url = BaseUrl + "/Food/Edit";

        public IWebElement FoodNameEdit => driver.FindElement(By.XPath("//input[@id='name']"));
        public IWebElement DescribeFoodEdit => driver.FindElement(By.XPath("//input[@id='description']"));

        public IWebElement AddPictureEdit => driver.FindElement(By.XPath("//input[@id='url']"));

        public IWebElement AddEditButton => driver.FindElement(By.XPath("//button[@type='submit']"));
    }
}
