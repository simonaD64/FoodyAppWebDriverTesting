using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace FoodyAppWebDriverTesting.Tests
{
    public class FoodyAppTests : BaseTest
    {
        public string lastCreatedFood;
        private string lastFoodDescription;
        

        [Test, Order(1)]
        public void AddFoodWithInvalidData()
        {
            addFoodPage.OpenPage();
            addFoodPage.addFood("", "");
            addFoodPage.AddButton.Click();
            addFoodPage.AssertErrorMessage();
        }

        [Test, Order(2)]
        public void AddRandomFood()
        {
            lastCreatedFood = GenerateRandomFoodName();
            lastFoodDescription = GenerateRandomFoodDescription(7);
            addFoodPage.OpenPage();
            addFoodPage.FoodNameInput.SendKeys(lastCreatedFood);
            addFoodPage.DescribeFoodInput.SendKeys(lastFoodDescription);
            addFoodPage.AddButton.Click();
            
            Assert.That(driver.Url, Is.EqualTo("http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85/"));

            var foodSection = driver.FindElement(By.XPath("//section[@id='scroll']"));
            actions.ScrollToElement(foodSection).Perform();
        }

        [Test, Order(3)]
        public void EditLastFood()
        {
            basePage.OpenPage();
            var foodSection = driver.FindElement(By.XPath("//section[@id='scroll']"));
            actions.ScrollToElement(foodSection).Perform();
           
            var editButtons = driver.FindElements(By.XPath("//*[contains(text(),'Edit')]"));

            var lastEditButton = editButtons[editButtons.Count - 1];
            string initialTitle = driver.Title;
            
            actions.MoveToElement(lastEditButton).Click().Perform();
            Assert.That(driver.Url.Contains("/Food/Edit"), "The URL does not contain '/Food/Edit' as expected.");

            editFoodPage.FoodNameEdit.Clear();
            editFoodPage.FoodNameEdit.SendKeys(lastCreatedFood);
            editFoodPage.AddEditButton.Click();

            string postEditTitle = driver.Title;
           
            if (initialTitle == postEditTitle)
            {
                Console.WriteLine("The title remains unchanged due to incomplete functionality.");
            }
            else
            {
                Console.WriteLine("The title has changed successfully.");
            }

            Assert.That(driver.Url, Is.EqualTo("http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85/"));
        }

        [Test, Order(4)]
        public void SearchFoodTitle()
        {
            basePage.OpenPage();
            basePage.SearchField.SendKeys(lastCreatedFood);
            basePage.SearchButton.Click();
        }

        [Test, Order(5)]
        public void DeleteFood()
        {
            basePage.OpenPage();

            var foodSection = driver.FindElement(By.XPath("//section[@id='scroll']"));
            actions.ScrollToElement(foodSection).Perform();

            var deleteButtons = driver.FindElements(By.XPath("//*[contains(text(),'Delete')]"));

            var lastDeletedButton = deleteButtons[deleteButtons.Count - 1];

            actions.MoveToElement(lastDeletedButton).Click().Perform();
        }

        [Test, Order(6)]
        public void SearchForDeletedFood()
        {
            basePage.OpenPage();

            basePage.SearchField.SendKeys(lastCreatedFood);
            basePage.SearchButton.Click();

            var noFoodsMessage = driver.FindElement(By.XPath("//h2[@class='display-4']"));
            Assert.That(noFoodsMessage.Text, Is.EqualTo("There are no foods :("), "Expected 'There are no foods :(' message is not displayed.");

            var addFoodButton = driver.FindElement(By.XPath("//a[@class='btn btn-primary btn-xl rounded-pill mt-5']"));
            Assert.That(addFoodButton.Displayed, Is.True, "The 'Add Food' button is not displayed.");
        }
    }
}