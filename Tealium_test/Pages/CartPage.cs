using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

            //var element = _driver.FindElement(By.ClassName("button btn-proceed-checkout btn-checkout"));
            /*Actions actions = new Actions(_driver);
            actions.MoveToElement(proceedToCheckout);
            actions.Perform();*/
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            Thread.Sleep(1000);
            proceedToCheckout.Click();
        }
    }
}
