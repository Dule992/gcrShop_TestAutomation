using NUnit.Framework;

namespace gcrShop_TestAutomation.TestSuite
{
    public class TestCase4 : BaseTest_AdminInterface
    {
        //(Business Rule: Admin Login will be locked for 5 minutes after 3 failed login attempts)
        [Test]
        public void adminLoginLockingFunctionality()
        {
            for (int i = 0; i < 3; i++)
            {
                loginPage.loginWith("username", "password");

                string actualMessage = loginPage.getErrorMessage();

                string expectedMessage = " Error: Invalid administrator login attempt.";

                Assert.AreEqual(expectedMessage, actualMessage);
            }

            loginPage.loginWith("username", "password");

            string actual = loginPage.getErrorMessage();

            string expected = " Error: The maximum number of login attempts has been reached. Please try again in 5 minutes.";

            Assert.AreEqual(expected, actual);


        }
    }
}
