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
        IWebElement txtFirstName => _driver.FindElement(By.Id("billing:firstname"));
        IWebElement txtLastName => _driver.FindElement(By.Id("billing:lastname"));
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
            txtCompany.SendKeys(companyname);
        }
        public void address(string address1)
        {
            txtAddress.SendKeys(address1);
        }
        public void city(string cityname)
        {
            txtCity.SendKeys(cityname);
        }
        public void state(string statename)
        {
            drpState.SendKeys(statename);
        }
        public void country(string countryname)
        {
            drpCountry.SendKeys(countryname);
        }
        public void zipcode(string zipnum)
        {
            txtZip.SendKeys(zipnum);
        }
        public void telnum(string tel)
        {
            txtTelephpone.SendKeys(tel);
        }
        public void faxNum(string fax)
        {
            txtFax.SendKeys(fax);
        }
        public void continuebutton()
        {
            btnContinue.Click();
        }
    }
}
