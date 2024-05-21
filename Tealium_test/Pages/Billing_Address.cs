using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tealium_test.Pages
{
    public class Billing_Address
    {
        private IWebDriver _driver;

        public Billing_Address(IWebDriver driver)
        {
            this._driver=driver;
        }
        IWebElement drpdwnSelectBillingAddress => _driver.FindElement(By.XPath("(//select[@class='address-select'])[1]"));
        IWebElement txtFirstName => _driver.FindElement(By.Id("billing:firstname"));
        IWebElement txtLastName => _driver.FindElement(By.XPath("(//input[@class='input-text required-entry'])[3]"));
        IWebElement txtCompany => _driver.FindElement(By.Id("billing:company"));
        IWebElement txtAddress => _driver.FindElement(By.Id("billing:street1"));
        IWebElement txtAddress2 => _driver.FindElement(By.Id("billing:street2"));
        IWebElement txtCity => _driver.FindElement(By.Id("billing:city"));
        IWebElement drpState => _driver.FindElement(By.XPath("(//select[@class='validate-select required-entry'])[1]"));
        IWebElement txtZip => _driver.FindElement(By.Id("billing:postcode"));
        IWebElement drpCountry => _driver.FindElement(By.XPath("(//select[@class='validate-select'])[1]"));
        IWebElement txtTelephpone => _driver.FindElement(By.Id("billing:telephone"));
        IWebElement txtFax => _driver.FindElement(By.ClassName("billing[fax]"));
        IWebElement btnContinue => _driver.FindElement(By.XPath("(//span[text()='Continue'])[1]"));
        public void selectBillingAddress(string billingAddress)
        {
            drpdwnSelectBillingAddress.SendKeys(billingAddress);
        }
        public void firstName(string fname)
        {
            txtFirstName.Clear();
            txtFirstName.SendKeys(fname);
        }
        public void lastName(string lname)
        {
            txtLastName.Clear();
            txtLastName.SendKeys(lname);
        }
        public void company(string companyname)
        {
            txtCompany.Clear();
            txtCompany.SendKeys(companyname);
        }
        public void address(string address1)
        {
            txtAddress.Clear();
            txtAddress.SendKeys(address1);
        }
        public void address02(string address2)
        {
            txtAddress2.Clear();
            txtAddress2.SendKeys(address2);
        }
        public void city(string cityname)
        {
            txtCity.Clear();
            txtCity.SendKeys(cityname);
        }
        public void state(string statename)
        {
            //txtLastName.Clear();
            drpState.SendKeys(statename);
        }
        public void country(string countryname)
        {
            //txtLastName.Clear();
            drpCountry.SendKeys(countryname);
        }
        public void zipcode(string zipnum)
        {
            txtZip.Clear();
            txtZip.SendKeys(zipnum);
        }
        public void telnum(string tel)
        {
            txtTelephpone.Clear();
            txtTelephpone.SendKeys(tel);
        }
        public void faxNum(string fax)
        {
            txtFax.Clear();
            txtFax.SendKeys(fax);
        }
        
        public void continuebutton()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            Thread.Sleep(1000);
            btnContinue.Click();
        }
    }
}
