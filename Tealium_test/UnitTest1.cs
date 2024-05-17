using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;
using Tealium_test.Models;
using Tealium_test.Pages;

namespace Tealium_test
{
    public class Tests
    {
        private IWebDriver _driver;
        private Login login;
        private ProductDetails productDetails;
        private CartPage cartPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.Navigate().GoToUrl("https://ecommerce.tealiumdemo.com/");
            _driver.Manage().Window.Maximize();
            login = new Login(_driver);
            productDetails= new ProductDetails(_driver);
            cartPage = new CartPage(_driver);
        }

        [Test]
        [Category("test1")]
        [TestCaseSource(nameof(Loginjson))]
        public void loginTest(LoginModel loginModel)
        {
            
            login.accountClick();
            login.loginClick();
            login.login(loginModel.email, loginModel.password);
            login.loginButton();
            Thread.Sleep(5000);

            //product details
            productDetails.btnProductChoice();
            Thread.Sleep(2000);
            productDetails.btnProductDetailsbutton();
            Thread.Sleep(2000);
            productDetails.choiceColor();
            Thread.Sleep(2000);
            productDetails.choiceSize();
            Thread.Sleep(2000);
            productDetails.choiceBtnAddtocart();
        }

        public static IEnumerable<LoginModel> Loginjson()
        {
            string jsonfilepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonString = File.ReadAllText(jsonfilepath);

            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);
            foreach (var loginData in loginModel)
            {
                yield return loginData;
            }
        }
        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}