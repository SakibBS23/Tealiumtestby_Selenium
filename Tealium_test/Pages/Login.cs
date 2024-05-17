using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tealium_test.Pages
{
    public class Login
    {
        private IWebDriver _driver;

        public Login(IWebDriver driver)
        {
            this._driver=driver;
        }
        IWebElement clickAccount => _driver.FindElement(By.XPath("(//span[@class='label'])[3]"));
        IWebElement clickLogin => _driver.FindElement(By.XPath("//a[contains(text(),'Log In')]"));
        IWebElement txtEmail => _driver.FindElement(By.Id("email"));
        IWebElement txtPassword => _driver.FindElement(By.Id("pass"));
        IWebElement buttonLogin => _driver.FindElement(By.XPath("//span[text()='Login']"));
        public void accountClick()
        {
            clickAccount.Click();
        }
        public void loginClick()
        {
            clickLogin.Click();
        }
        public void login(string email, string password)
        {
            txtEmail.SendKeys(email);
            txtPassword.SendKeys(password);
        }
        public void loginButton()
        {
            buttonLogin.Submit();
        }
    }
}
