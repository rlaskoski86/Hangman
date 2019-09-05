using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;

namespace Hangman.UITest.PageObjectModels
{
    class ApplicationPage
    {
        public IWebDriver Driver { get; }

        private const string PagePath = "apply";

        public ApplicationPage(IWebDriver driver)
        {
            Driver = driver;

            //PageFactory.InitElements(driver, this);
        }

        public void NavigateTo()
        {
            var root = new Uri(Driver.Url).GetLeftPart(UriPartial.Authority);

            var url = $"{root}/{PagePath}";

            Driver.Navigate().GoToUrl(url);
        }

        [FindsBy(How = How.Id, Using = "txtUser")]
        private IWebElement User { get; set; }

        public void EnterUser(string user)
        {
            User.SendKeys(user);
        }

        [FindsBy(How = How.Id, Using = "btnLogin")]
        private IWebElement ApplyButton { get; set; }

        public ApplicationCompletePage LoginApplication()
        {
            ApplyButton.Click();

            return new ApplicationCompletePage(Driver);
        }

    }
}
