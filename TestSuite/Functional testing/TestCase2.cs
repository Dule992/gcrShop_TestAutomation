using gcrShop_TestAutomation.Admin_login_page;
using NUnit.Framework;

namespace gcrShop_TestAutomation.TestSuite
{
    public class TestCase2 : BaseTest_AdminInterface
    {
        [Test]
        public void verifyRedirectFunctionalityFromAdminToUserInterfaceInGcrShopApplication()
        {
            AdminsPage adminsPage = loginPage.loginWith("gcreddy", "Temp@2020");

            adminsPage.clickOnlineCatalog();

            Assert.IsTrue(adminsPage.isExpectedUrl("http://gcreddy.com/project/"));

        }
    }
}
