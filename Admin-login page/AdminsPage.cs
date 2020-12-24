using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace gcrShop_TestAutomation.Admin_login_page
{
    public class AdminsPage : BasePage
    {
        //navigation bar
        private By administrationNav = By.XPath("//a[contains(text(),'Administration')]");
        private By onlineCatalogNav = By.XPath("//a[contains(text(),'Online Catalog')]");
        private By loggedOutNav = By.XPath("//a[contains(text(),'Logoff')]");

        //menu
        private By catalogButton = By.LinkText("Catalog");
        private By customersButton = By.LinkText("Customers");
        private By localizationButton = By.XPath("//a[contains(text(),'Localization')]");
        private By reportsButton = By.XPath("//a[contains(text(),'Reports')]");


        public AdminsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public bool isLoggedOutDisplay()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var loogedOutElement = wait.Until(x => x.FindElement(loggedOutNav));

            return isDisplayed(loggedOutNav);
        }

        public void clickOnlineCatalog()
        {
            find(onlineCatalogNav);
            click(onlineCatalogNav);
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

        public bool isElementsAvailableOnAdminsPage()
        {
            bool administration = isDisplayed(administrationNav);
            bool onlineCatalog = isDisplayed(onlineCatalogNav);
            bool loggedOut = isDisplayed(loggedOutNav);
            bool catalog = isDisplayed(catalogButton);
            bool customers = isDisplayed(customersButton);
            bool localization = isDisplayed(localizationButton);
            bool reports = isDisplayed(reportsButton);

            if ((administration && onlineCatalog && loggedOut && catalog && customers && localization && reports) == true)
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

