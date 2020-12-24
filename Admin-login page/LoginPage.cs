using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace gcrShop_TestAutomation.Admin_login_page
{
    public class LoginPage : BasePage
    {
        private By usernameField = By.XPath("//input[@name='username']");
        private By passwordField = By.XPath("//input[@name='password']");
        private By loginButton = By.CssSelector(".ui-button-text");
        private By errorMessage = By.XPath("//td[@class='messageStackError']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void setUsername(string username)
        {
            type(username, usernameField);
        }

        public void setPassword(string password)
        {
            type(password, passwordField);
        }

        public AdminsPage clickLoginButton()
        {
            click(loginButton);
            return new AdminsPage(driver);
        }

        public AdminsPage loginWith(string username, string password)
        {
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var usernameElement = webDriverWait.Until(x => x.FindElement(usernameField));

            setUsername(username);
            setPassword(password);
            click(loginButton);

            return clickLoginButton();
        }

        public string getErrorMessage()
        {
            return find(errorMessage).Text;
        }

        public bool isExpectedUrl(string url)
        {
            string currentUrl = driver.Url;

            Console.WriteLine(currentUrl);
            if (currentUrl.Contains(url))
            {
                return true;
            }
            return false;
        }

        public bool isElementsAvailabileOnLoginPage()
        {
            bool username = isDisplayed(usernameField);
            bool password = isDisplayed(passwordField);
            bool logButton = isDisplayed(loginButton);

            if ((username && password && logButton) == true)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
