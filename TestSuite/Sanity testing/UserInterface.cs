using NUnit.Framework;

namespace gcrShop_TestAutomation.TestSuite.Sanity_testing
{
    public class UserInterface : BaseTest_UserInterface
    {
        [Test]
        public void verifyLaunchApplicationOfTheUserInterface()
        {
            bool actualURL = userPage.isExpectedUrl("https://gcreddy.com/project/");

            Assert.IsTrue(actualURL);
        }

        [Test]
        public void verifyMandatoryElementsAvailabilityInTheUserInterfaceHomePage()
        {
            bool actualResult = userPage.isElementsAvailableOnUsersPage();

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void verifyCustomerRegistrationWithValidData()
        {
            userPage.registrationAccount("male", "Mariano", "Beneventi", "02/14/1959", "MarianoBeneventi@teleworm.us",
                "Via Giberti 18", "10080", "Lusiglie", "TO", "Italy", "0313 3055405", "vee3Veith");

            bool actualResult = userPage.isCreatedAccount();

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void verifyCustomerLoginWithValidData()
        {
            userPage.loginUserPage("MarianoBeneventi@teleworm.us", "vee3Veith");

            bool actualResult = userPage.isLoginSuccesfuly("Mariano");

            Assert.IsTrue(actualResult);
        }

        [Test]
        [Description("Initial State, Add a Product, Update Quantity, and Remove a Product")]
        public void verifyShoppingCart()
        {
            userPage.shoppingAndUpdateQuanitity("Selenium", 10);

            bool actualUpdated = userPage.verifyQuantityUpdated(10);

            bool actualRemoved = userPage.verifyRemoveProduct();

            Assert.IsTrue(actualUpdated);
            Assert.IsTrue(actualRemoved);
        }

        [Test]
        public void verifyCheckoutProcess()
        {
            userPage.loginUserPage("MarianoBeneventi@teleworm.us", "vee3Veith");
            userPage.shoppingAndUpdateQuanitity("Selenium", 1);
            userPage.checkoutProcess();
            bool actualProcessedMessage = userPage.verifyProcessedMessage();

            Assert.IsTrue(actualProcessedMessage);
        }

        [Test]
        public void logOffAndCloseApplication()
        {

            userPage.loginUserPage("MarianoBeneventi@teleworm.us", "vee3Veith");
            userPage.logOff();

            bool actualURL = userPage.isExpectedUrl("https://gcreddy.com/project/");

            Assert.IsTrue(actualURL);
        }
    }
}
