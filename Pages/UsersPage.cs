using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace gcrShop_TestAutomation.Admin_login_page
{
    public class UsersPage : BasePage
    {
        //navigation bar
        private By cartContentsButton = By.XPath("//span[contains(text(),'Cart Contents')]");
        private By checkoutButton = By.XPath("//span[contains(text(),'Checkout')]");
        private By myAccountButton = By.XPath("//span[contains(text(),'My Account')]");
        private By logOffButton = By.XPath("//span[contains(text(),'Log Off')]");

        //categories sidebar 
        private By mobileLink = By.XPath("//a[contains(text(),'Mobile')]");
        private By powderLink = By.XPath("//div[@class='ui-widget-content infoBoxContents']/a[contains(text(),'Powder')]");
        private By testingLink = By.XPath("//a[contains(text(),'Testing')]");
        private By booksLink = By.XPath("//a[contains(text(),'Books')]");
        private By tabLink = By.XPath("//a[contains(text(),'Tab')]");
        private By shoppingCartLink = By.XPath("//a[contains(text(),'Shopping Cart')]");

        //registration account
        private By createAnAccountLink = By.XPath("//u[contains(text(),'create an account')]");
        private By genderRadioButton;
        private By firstNameField = By.XPath("//input[@name='firstname']");
        private By lastNameField = By.XPath("//input[@name='lastname']");
        private By dateOfBirthField = By.CssSelector("#dob");
        private By emailAddressField = By.XPath("//input[@name='email_address']");
        private By streetAddressField = By.XPath("//input[@name='street_address']");
        private By postCodeField = By.XPath("//input[@name='postcode']");
        private By cityField = By.XPath("//input[@name='city']");
        private By stateField = By.XPath("//input[@name='state']");
        private By phoneField = By.XPath("//input[@name='telephone']");
        private By passwordField = By.XPath("//input[@name='password']");
        private By confPasswordField = By.XPath("//input[@name='confirmation']");
        private By continueButton = By.XPath("//span[contains(text(),'Continue')]");
        private By createdAccountMessage = By.XPath("//h1[contains(text(),'Your Account Has Been Created!')]");

        //login User page
        private By loginButton = By.XPath("//u[contains(text(),'login')]");
        private By emailField = By.XPath("//input[@name='email_address']");
        private By passField = By.XPath("//input[@name='password']");
        private By signInButton = By.XPath("//span[contains(text(),'Sign In')]");
        private By loginSuccessfuly;

        //shopping cart
        private By initialState;
        private By productLink;
        private By addToCartButton = By.XPath("//span[contains(text(),'Add to Cart')]");
        private By quantityField = By.XPath("//input[@name='cart_quantity[]']");
        private By updateButton = By.XPath("//span[contains(text(),'Update')]");
        private By itemsQuantity;
        private By removeButton = By.XPath("//a[contains(text(),'remove')]");

        //checkout
        private By checkoutButton2 = By.XPath("//a[@id='tdb6']");
        private By confirmButton = By.XPath("//span[contains(text(),'Confirm Order')]");
        private By processedMessage = By.XPath("//h1[contains(text(),'Your Order Has Been Processed!')]");



        public UsersPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
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

        public bool isElementsAvailableOnUsersPage()
        {
            bool cartContents = isDisplayed(cartContentsButton);
            bool checkout = isDisplayed(checkoutButton);
            bool mobile = isDisplayed(mobileLink);
            bool powder = isDisplayed(powderLink);
            bool testing = isDisplayed(testingLink);
            bool books = isDisplayed(booksLink);
            bool tab = isDisplayed(tabLink);
            bool shoopingCart = isDisplayed(shoppingCartLink);

            try
            {
                if ((cartContents && checkout && mobile && powder && testing && books && tab && shoopingCart) == true)
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

        public void registrationAccount(string gender, string name, string lastname, string birth, string email, string street, string postCode, string city,
            string state, string country, string phone, string password)
        {
            click(createAnAccountLink);

            if (gender == "male")
            {
                gender = "m";
                genderRadioButton = By.XPath($"//input[@name='gender'] [@value='{gender}']");
            }
            else
            {
                gender = "f";
                genderRadioButton = By.XPath($"//input[@name='gender'] [@value='{gender}']");
            }

            click(genderRadioButton);

            type(name, firstNameField);
            type(lastname, lastNameField);
            type(birth, dateOfBirthField);
            type(email, emailAddressField);
            type(street, streetAddressField);
            type(postCode, postCodeField);
            type(city, cityField);
            type(state, stateField);
            new SelectElement(driver.FindElement(By.XPath("//select[@name='country']"))).SelectByText(country);
            type(phone, phoneField);
            type(password, passwordField);
            type(password, confPasswordField);

            click(continueButton);
        }

        public bool isCreatedAccount()
        {
            if (isDisplayed(createdAccountMessage) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void loginUserPage(string email, string password)
        {
            click(loginButton);
            type(email, emailField);
            type(password, passField);
            click(signInButton);
        }

        public bool isLoginSuccesfuly(string username)
        {
            loginSuccessfuly = By.XPath($"//span[@class='greetUser'] [contains(text(),'{username}!')]");
            if (isDisplayed(loginSuccessfuly) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void shoppingAndUpdateQuanitity(string productName, int quantity)
        {
            initialState = By.XPath($"//div[contains(text(),'0 items')]");
            bool items = isDisplayed(initialState);

            if (items == true)
            {
                productLink = By.XPath($"//a[contains(text(),'{productName}')]");

                click(productLink);

                click(addToCartButton);

                type(quantity.ToString(), quantityField);

                click(updateButton);

            }
        }

        public bool verifyQuantityUpdated(int quantity)
        {
            itemsQuantity = By.XPath($"//td[contains(text(),'{quantity} x')]");

            bool items = isDisplayed(itemsQuantity);

            if (items == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool verifyRemoveProduct()
        {
            click(removeButton);

            initialState = By.XPath($"//div[contains(text(),'0 items')]");
            bool items = isDisplayed(initialState);

            if (items == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void checkoutProcess()
        {
            click(checkoutButton2);

            for (int i = 0; i < 2; i++)
            {
                click(continueButton);
            }

            click(confirmButton);
        }

        public bool verifyProcessedMessage()
        {
            if (isDisplayed(processedMessage) == true)
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
            click(logOffButton);
        }
    }

}
