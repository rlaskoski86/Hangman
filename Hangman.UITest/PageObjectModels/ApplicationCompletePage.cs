﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.UITest.PageObjectModels
{
    internal class ApplicationCompletePage
    {

        public IWebDriver Driver { get; }

        public ApplicationCompletePage(IWebDriver driver)
        {
            Driver = driver;

           // PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "fullName")]
        private IWebElement Name { get; set; }

        [FindsBy(How = How.Id, Using = "decision")]
        private IWebElement Decision { get; set; }

        public string FullName => Name.Text;

        public string ApplicationDecision => Decision.Text;
        
    }
}
