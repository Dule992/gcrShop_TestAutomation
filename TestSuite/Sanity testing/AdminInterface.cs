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
    }
}
