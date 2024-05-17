using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tealium_test.Pages
{
    public class CartPage
    {
        private IWebDriver _driver;

        public CartPage(IWebDriver driver)
        {
            this._driver=driver;
        }
        IWebElement country => _driver.FindElement(By.Id("country"));
        IWebElement state => _driver.FindElement(By.Id("region_id"));
        IWebElement zip => _driver.FindElement(By.Id("postcode"));
        IWebElement proceedToCheckout => _driver.FindElement(By.XPath("(//span[text()='Proceed to Checkout'])[2]"));
        public void drpdwnCountry(string CountryName)
        {
            country.SendKeys(CountryName);
        }
        public void drpdwnState(string StateName)
        {
            state.SendKeys(StateName);
        }
        public void txtZip(string ZipNumber)
        {
            zip.SendKeys(ZipNumber);
        }
        public void checkoutProceed()
        {
            proceedToCheckout.Click();
        }
    }
}
