using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using Tealium_test.Models;
using Tealium_test.Pages;
using Tealium_test.Utility;

namespace Tealium_test
{

    public class Tests
    {
        private IWebDriver _driver;
        private Login login;
        private ProductDetails productDetails;
        private CartPage cartPage;
        private Billing_Address billingAddress;
        private ShippingMethod shippingMethod;
        private LoginModel loginModelData;
        private CartModel cartModelData;
        private BillingAddressModel billingAddressModelData;

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
            billingAddress= new Billing_Address(_driver);
            shippingMethod= new ShippingMethod(_driver);

        }

        [Test]
        //[TestCaseSource(nameof(CombinedJson())]
        public void loginTest()
        {
            /*string loginjsonfilepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            string cartjsonfilepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cart.json");*/
            string loginjsonfilepath = "C:\\Users\\BS-Test\\source\\repos\\Tealium_test\\Tealium_test\\login.json";
            string cartjsonfilepath = "C:\\Users\\BS-Test\\source\\repos\\Tealium_test\\Tealium_test\\Cart.json";
            string BillingAddressjsonfilepath = "C:\\Users\\BS-Test\\source\\repos\\Tealium_test\\Tealium_test\\BillingAddress.json";

            try
            {
                loginModelData = JSONReader.ReadJsonFile<LoginModel>(loginjsonfilepath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            try
            {
                cartModelData = JSONReader.ReadJsonFile<CartModel>(cartjsonfilepath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            try
            {
                billingAddressModelData = JSONReader.ReadJsonFile<BillingAddressModel>(BillingAddressjsonfilepath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }


            login.accountClick();
            login.loginClick();
           
            login.login(loginModelData.email, loginModelData.password);
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

            //Add to Cart
            Thread.Sleep(2000);
            cartPage.drpdwnCountry(cartModelData.CountryName);
            Thread.Sleep(2000);
            cartPage.drpdwnState(cartModelData.StateName);
            Thread.Sleep(2000);
            cartPage.txtZip(cartModelData.ZipNumber);
            Thread.Sleep(5000);
            cartPage.checkoutProceed();
            Thread.Sleep(3000);

            //billing address
            billingAddress.selectBillingAddress(billingAddressModelData.drpdwnSelect);
            Thread.Sleep(3000);
            billingAddress.firstName(billingAddressModelData.firstName);
            Thread.Sleep(2000);
            billingAddress.lastName(billingAddressModelData.lastName);
            Thread.Sleep(2000);
            billingAddress.company(billingAddressModelData.company);
            Thread.Sleep(2000);
            billingAddress.address(billingAddressModelData.address1);
            Thread.Sleep(2000);
            billingAddress.address02(billingAddressModelData.address2);
            Thread.Sleep(2000);
            billingAddress.city(billingAddressModelData.city);
            Thread.Sleep(2000);
            billingAddress.state(billingAddressModelData.state);
            Thread.Sleep(2000);
            billingAddress.zipcode(billingAddressModelData.zipcode);
            Thread.Sleep(2000);
            billingAddress.country(billingAddressModelData.country);
            Thread.Sleep(2000);
            billingAddress.telnum(billingAddressModelData.phone);
            //billingAddress.faxNum(billingAddressModelData.fax);
            Thread.Sleep(2000);
            billingAddress.continuebutton();

            //shipping to checkout
            Thread.Sleep(2000);
            shippingMethod.freeShipping();
            Thread.Sleep(2000);
            shippingMethod.shippingContinue();
            Thread.Sleep(2000);
            shippingMethod.DeliveryContinue();
            Thread.Sleep(2000);
            shippingMethod.placeOrder();
        }

        /*public static IEnumerable<CombinedModel> CombinedJson()
        {
            string loginjsonfilepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            string cartjsonfilepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cart.json");
            var loginjsonString = File.ReadAllText(loginjsonfilepath);
            var cartjsonString = File.ReadAllText(cartjsonfilepath);

            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(loginjsonString);
            var cartModel = JsonSerializer.Deserialize<List<LoginModel>>(cartjsonString);
            for (int i = 0; i < loginModel.Count; i++)
            {
                yield return new CombinedModel { loginModel = loginModel[i], cartModel = cartModel[i % cartModel.Count] };
            }

        }*/
        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}