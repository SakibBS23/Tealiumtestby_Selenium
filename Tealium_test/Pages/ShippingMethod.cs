using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tealium_test.Pages
{
    public class ShippingMethod
    {
        private IWebDriver _driver;

        public ShippingMethod(IWebDriver driver)
        {
            this._driver=driver;
        }
        IWebElement checkboxFreeShipping => _driver.FindElement(By.XPath("(//input[@name='shipping_method'])[2]"));
        IWebElement btnshippingContinue => _driver.FindElement(By.XPath("(//span[text()='Continue'])[3]"));
        IWebElement btncashonDeliveryContinueBtn => _driver.FindElement(By.XPath("(//button[@class='button'])[2]"));
        IWebElement btnPlaceOrder => _driver.FindElement(By.XPath("//button[@class='button btn-checkout']"));
        public void freeShipping()
        {
            checkboxFreeShipping.Click();
        }
        public void shippingContinue()
        {
            btnshippingContinue.Click();
        }
        public void DeliveryContinue()
        {
            btnshippingContinue.Click();
        }
        public void placeOrder()
        {
            btnPlaceOrder.Click();
        }
    }
}
