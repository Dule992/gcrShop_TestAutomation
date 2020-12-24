using gcrShop_TestAutomation.Admin_login_page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace gcrShop_TestAutomation.TestSuite
{
    public class BaseTest_AdminInterface
    {
        private IWebDriver driver;
        private readonly string AUT_URL = "https://gcreddy.com/project/admin/login.php";
        protected LoginPage loginPage;

        [SetUp]
        public void setUp()
        {
            driver = new ChromeDriver();

            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(AUT_URL);

            loginPage = new LoginPage(driver);
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }

    }
}
