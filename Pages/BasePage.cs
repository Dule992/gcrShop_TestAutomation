using OpenQA.Selenium;

namespace gcrShop_TestAutomation.Admin_login_page
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected IWebElement find(By locator)
        {
            return driver.FindElement(locator);
        }

        protected void type(string text, By locator)
        {
            find(locator).Clear();
            find(locator).SendKeys(text);
        }

        protected void click(By locator)
        {
            find(locator).Click();
        }

        protected bool isDisplayed(By locator)
        {
            try
            {
                return find(locator).Displayed;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }
    }
}
