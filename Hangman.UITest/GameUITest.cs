using Hangman.UITest.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using Xunit;

namespace Hangman.UITest
{
    public class GameUITest
    {
        private readonly IWebDriver _driver;
        private readonly ApplicationPage _applicationPage;

        public GameUITest()
        {
            _driver = new ChromeDriver();

            _driver.Navigate().GoToUrl("http://localhost:44108/");

            _applicationPage = new ApplicationPage(_driver);
            _applicationPage.NavigateTo();
        }


        [Fact]
        public void ShouldPlayGame()
        {
            _applicationPage.EnterUser("Ricardo");

            DelayForDemoVideo();

            _applicationPage.LoginApplication();
        }

        private static void DelayForDemoVideo()
        {
            Thread.Sleep(1000);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
