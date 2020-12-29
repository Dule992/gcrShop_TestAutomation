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

        //catalog list
        private By categories_productsButton = By.XPath("//a[contains(text(),'Categories/Products')]");
        private By manufacturerButton = By.XPath("//a[contains(text(),'Manufacturers')]");

        //categories / products page
        private By newCategoryButton = By.XPath("//span[contains(text(),'New Category')]");
        private By newProductButton = By.XPath("//span[contains(text(),'New Product')]");
        private By categoryNameField = By.XPath("//input[@name='categories_name[1]']");
        private By saveButton = By.XPath("//span[contains(text(),'Save')]");


        //in list of categories and products page
        private By categoryName;

        //in manufacutrers page
        private By insertButton = By.XPath("//span[contains(text(),'Insert')]");
        private By manufacturerNameField = By.XPath("//input[@name='manufacturers_name']");

        //in list of manufacuturers
        private By manufactureName;

        //in products page filling atributes
        private By productName;
        private By dateAvailable = By.XPath("//input[@id='products_date_available']");
        private By productsNameField = By.XPath("//input[@name='products_name[1]']");
        private By productsPriceNetField = By.XPath("//input[@name='products_price']");
        private By productstPriceGrossField = By.XPath("//input[@name='products_price_gross']");
        private By productsDescriptionField = By.TagName("textarea");
        private By productsQuantityField = By.XPath("//input[@name='products_quantity']");
        private By productsModelField = By.XPath("//input[@name='products_model']");
        private By productsWeightField = By.XPath("//input[@name='products_weight']");

        //localization list
        private By currenciesButton = By.XPath("//a[contains(text(),'Currencies')]");

        //in currencies page and atributes of new currency
        private By currencyName;
        private By newCurrencyButton = By.XPath("//span[contains(text(),'New Currency')]");
        private By titleField = By.XPath("//input[@type='text'] [@name='title']");
        private By codeField = By.XPath("//input[@type='text'] [@name='code']");
        private By symbolLeftField = By.XPath("//input[@type='text'] [@name='symbol_left']");
        private By symbolRightField = By.XPath("//input[@type='text'] [@name='symbol_right']");
        private By decimalPointField = By.XPath("//input[@type='text'] [@name='decimal_point']");
        private By thousandsPointField = By.XPath("//input[@type='text'] [@name='thousands_point']");
        private By decimalPlacesField = By.XPath("//input[@type='text'] [@name='decimal_places']");
        private By valueField = By.XPath("//input[@type='text'] [@name='value']");

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

            try
            {
                if ((administration && onlineCatalog && loggedOut && catalog && customers && localization && reports) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return false;
            }


        }

        public void addCategory(string categoryName)
        {
            click(catalogButton);

            click(categories_productsButton);

            click(newCategoryButton);

            type(categoryName, categoryNameField);

            click(saveButton);
        }

        public bool isCategoryAdded(string nameCategory)
        {
            categoryName = By.XPath($"//strong[contains(text(),'{nameCategory}')]");

            bool nameDisplayed = isDisplayed(categoryName);

            if (nameDisplayed == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void addManufacturer(string manufacturerName)
        {
            click(catalogButton);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var manufacturerButtElement = wait.Until(ExpectedConditions.ElementToBeClickable(manufacturerButton));

            click(manufacturerButton);

            click(insertButton);

            type(manufacturerName, manufacturerNameField);

            click(saveButton);
        }

        public bool isManufacutrerAdded(string nameManufacutrer)
        {
            manufactureName = By.XPath($"//strong[contains(text(),'{nameManufacutrer}')]");

            bool nameDisplayed = isDisplayed(manufactureName);

            if (nameDisplayed == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void addProduct(string productName, int prodcutPriceNet, int productPriceGross, string productDescription, int productQuantity,
            string productModel, int productWeight)
        {
            click(catalogButton);

            click(categories_productsButton);

            click(newProductButton);

            type(DateTime.Today.ToString("yyyy-MM-dd"), dateAvailable);

            type(productName, productsNameField);

            type(prodcutPriceNet.ToString(), productsPriceNetField);

            type(productPriceGross.ToString(), productstPriceGrossField);

            type(productDescription, productsDescriptionField);

            type(productQuantity.ToString(), productsQuantityField);

            type(productModel, productsModelField);

            type(productWeight.ToString() + " g", productsWeightField);

            click(saveButton);

        }

        public bool isProductAdded(string nameProduct)
        {

            productName = By.XPath($"//strong[contains(text(),'{nameProduct}')]");

            bool nameDisplayed = isDisplayed(productName);

            if (nameDisplayed == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void addCurrency(string title, string code, string symbolLeft, string symbolRight, string decimalPoint, string thousandsPoint,
            int decimalPlaces, int value)
        {
            click(localizationButton);

            click(currenciesButton);

            click(newCurrencyButton);

            type(title, titleField);

            type(code, codeField);

            type(symbolLeft, symbolLeftField);

            type(symbolRight, symbolRightField);

            type(decimalPoint, decimalPointField);

            type(thousandsPoint, thousandsPointField);

            type(decimalPlaces.ToString(), decimalPlacesField);

            type(value.ToString(), valueField);

            click(saveButton);
        }

        public bool isCurrencyAdded(string nameCurrency)
        {

            currencyName = By.XPath($"//td[@class='dataTableContent'] [text()='{nameCurrency}']");

            bool nameDisplayed = isDisplayed(currencyName);

            if (nameDisplayed == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void logOff()
        {
            click(loggedOutNav);
        }

    }


}

