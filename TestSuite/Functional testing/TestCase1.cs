using gcrShop_TestAutomation.Admin_login_page;
using NUnit.Framework;

namespace gcrShop_TestAutomation.TestSuite
{
    public class TestCase1 : BaseTest_AdminInterface
    {
        [Test]
        public void verifyAdminLoginFunctionalityInGcrShopApplicationAdminInterfaces()
        {
            loginPage.setUsername("gcreddy");
            loginPage.setPassword("Temp@2020");
            AdminsPage adminsPage = loginPage.clickLoginButton();

            Assert.IsTrue(adminsPage.isLoggedOutDisplay());
        }
    }
}