using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SwagClassLib
{
    public class CartPage
    {
        private IWebDriver _driver;


        
        [FindsBy(How= How.XPath, Using="//button[@id='checkout']")]
        private IWebElement _CheckOut;

        public CartPage(IWebDriver driver)

        {
          
        _driver =driver; 
        PageFactory.InitElements(_driver,this);

        }

        public void CheckOut(){

        _CheckOut.Click();

        }
    }
}