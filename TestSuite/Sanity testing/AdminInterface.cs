using gcrShop_TestAutomation.Admin_login_page;
using NUnit.Framework;

namespace gcrShop_TestAutomation.TestSuite.Sanity_testing
{
    public class AdminInterface : BaseTest_AdminInterface
    {
        [Test]
        public void verifyLaunchApplicationOfTheUserInterface()
        {
            bool actualURL = loginPage.isExpectedUrl("http://gcreddy.com/project/admin/login.php");
            Assert.IsTrue(actualURL);
        }

        [Test]
        public void verifyMandatoryElementsAvailabilityInTheAdminInterfaceLoginPage()
        {
            bool actualElements = loginPage.isElementsAvailabileOnLoginPage();
            Assert.IsTrue(actualElements);
        }

        [Test]
        public void verifyAdminLoginWithValidUsernameAndValidPassword()
        {
            loginPage.setUsername("gcreddy");
            loginPage.setPassword("Temp@2020");

            AdminsPage adminsPage = loginPage.clickLoginButton();

            Assert.IsTrue(adminsPage.isLoggedOutDisplay());
        }

        [Test]
        public void verifyMandatoryElementsAvailabilityInTheAdminInterfaceIndexPage()
        {
            loginPage.setUsername("gcreddy");
            loginPage.setPassword("Temp@2020");
            AdminsPage adminsPage = loginPage.clickLoginButton();

            bool actualElements = adminsPage.isElementsAvailableOnAdminsPage();

            Assert.IsTrue(actualElements);
        }

        [Test]
        public void addCategory()
        {
            loginPage.setUsername("gcreddy");
            loginPage.setPassword("Temp@2020");
            AdminsPage adminsPage = loginPage.clickLoginButton();

            adminsPage.addCategory("Testing");

            bool actualResult = adminsPage.isCategoryAdded("Testing");

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void addManufacturer()
        {
            loginPage.setUsername("gcreddy");
            loginPage.setPassword("Temp@2020");
            AdminsPage adminsPage = loginPage.clickLoginButton();

            adminsPage.addManufacturer("Manufacturer_test");

            bool actualResult = adminsPage.isManufacutrerAdded("Manufacturer_test");

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void addProduct()
        {
            loginPage.setUsername("gcreddy");
            loginPage.setPassword("Temp@2020");
            AdminsPage adminsPage = loginPage.clickLoginButton();

            adminsPage.addProduct("Apple iPhone 11", 500, 789, "6.1, RAM: 4 GB, Memory: 64 GB, " +
                "Back cam: 12.0 Mpix + 12.0 Mpix, Battery: 3110 mAh, Resolution: 1792 x 828",
                100, "MWLW2SE/A", 194);

            bool actualResult = adminsPage.isProductAdded("Apple iPhone 11");

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void addCurrency()
        {
            loginPage.setUsername("gcreddy");
            loginPage.setPassword("Temp@2020");
            AdminsPage adminsPage = loginPage.clickLoginButton();

            adminsPage.addCurrency("Serbian Dinar", "RSD", "", "", ".", ",", 2, 1);

            bool actualResult = adminsPage.isCurrencyAdded("Serbian Dinar");

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void logOff()
        {
            loginPage.setUsername("gcreddy");
            loginPage.setPassword("Temp@2020");
            AdminsPage adminsPage = loginPage.clickLoginButton();

            adminsPage.isLoggedOutDisplay();
            adminsPage.logOff();

            bool actualURL = loginPage.isExpectedUrl("http://gcreddy.com/project/admin/login.php");

            Assert.IsTrue(actualURL);

        }


    }
}
