using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SwagClassLib;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;


namespace SwagMstest
{
    [TestClass]
    public class UnitTest1
    {
    
        IWebDriver driver;

        //Naviagate Url Website

        [TestInitialize]
        public void start_Browser()

        {
            driver = new ChromeDriver(@"C:\Users\E009146\RootFolder");
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
         
        }

        //LogIn Page Credentials 
        
        [DataTestMethod]
        [Ignore]
        [DataRow("standard_user","secret_sauce")]
        
        public void Login_(string user, string pass)
        {
            LogInPage log =new LogInPage(driver);
            log.username(user);
            log.password(pass);
            log.loginbutton();
        }

        //Product Page Method

        [TestMethod]
        [Ignore]
        public void productpage(){

            LogInPage log =new LogInPage(driver);
            log.username("standard_user");
            log.password("secret_sauce");
            log.loginbutton();
            SwagClassLib.ProductsPage products =new SwagClassLib.ProductsPage(driver);
            Thread.Sleep(3000);
            products.backpackcart();
            products.bikelightcart();
            //products.cartlink();
            products.cartlink();
            SwagClassLib.CartPage Cpage =new SwagClassLib.CartPage(driver);
            Cpage.CheckOut();
            SwagClassLib.CheckOutPage  check=new SwagClassLib.CheckOutPage(driver);
            Thread.Sleep(2000);
            check.FirstName("Saikiran");
            check.LastName("Gujjeti");
            check.PostalCode("5983");
            check.Continue();
            check.Finish();
            Thread.Sleep(2000);

            //Going to Back HomePage
            check.Back();
            Thread.Sleep(2000); 

            //Going to MenuBar
            products.menubtn();
            //Logout Session
            products.logoutlink();

            
         
            }

            //duplicate Images 

           [DataTestMethod] 
           [Ignore]     
           [DataRow("problem_user","secret_sauce")]
           public void problemuser(string user, string pass)
        {
            LogInPage log =new LogInPage(driver);
            log.username(user);
            log.password(pass);
            log.loginbutton();
            Thread.Sleep(3000);
            SwagClassLib.ProductsPage product = new SwagClassLib.ProductsPage(driver);
            string actualbackpackimg =product.puserbackpackimage();
            string expectedbackpackimg = "/static/media/sauce-backpack-1200x1500.34e7aa42.jpg";
            Assert.AreEqual(expectedbackpackimg,actualbackpackimg,"problem user image doesnot match");

        }



        //locked User Toast Mesaage
        [DataTestMethod]
         public void locked_out_user(){

            LogInPage log =new LogInPage(driver);
            log.username("locked_out_user");
            log.password("secret_sauce");
            log.loginbutton();
            string actual4 =log.locked_out_user();
            string expectedname4 ="Epic sadface: Sorry, this user has been locked out.";
            Assert.AreEqual(expectedname4,actual4,"method fail");
            log.locked_out_user();
        }
            
        }

    }




