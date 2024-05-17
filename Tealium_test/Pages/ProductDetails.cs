using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tealium_test.Pages
{
    public class ProductDetails
    {
        private IWebDriver _driver;

        public ProductDetails(IWebDriver driver)
        {
            this._driver=driver;
        }
        IWebElement productChoice => _driver.FindElement(By.XPath("(//a[@class='level0 has-children'])[2]"));
        //IWebElement productDetailsbutton => _driver.FindElement(By.XPath("(//a[text()='Plaid Cotton Shirt'])/../../div/a[text()='View Details']"));
        IWebElement productDetailsbutton => _driver.FindElement(By.XPath("(//a[@title='Plaid Cotton Shirt'])[2]"));
        IWebElement color => _driver.FindElement(By.XPath("(//span[@class='swatch-label']//img)[2]"));
        IWebElement size => _driver.FindElement(By.XPath("//span[text()[normalize-space()='M']]"));
        IWebElement btnAddtocart => _driver.FindElement(By.XPath("(//span[text()='Add to Cart'])[2]"));
        public void btnProductChoice()
        {
            productChoice.Click();
        }
        public void btnProductDetailsbutton()
        {
            /*Actions actions = new Actions(_driver);
            actions.MoveToElement(productDetailsbutton);
            actions.Perform();
            Thread.Sleep(1000);
            productDetailsbutton.Click();*/
            _driver.Navigate().GoToUrl("https://ecommerce.tealiumdemo.com/plaid-cotton-shirt-582.html");
        }
        public void choiceColor()
        {
            color.Click();
        }
        public void choiceSize()
        {
            size.Click();
        }
        public void choiceBtnAddtocart()
        {
            btnAddtocart.Click();
        }
    }
}
