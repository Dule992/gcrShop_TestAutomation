using NUnit.Framework;

namespace gcrShop_TestAutomation.TestSuite
{
    public class TestCase3 : BaseTest_AdminInterface
    {
        [TestCase("gcreddy", "admin@123", TestName = "Positive Scenario", ExpectedResult = "http://gcreddy.com/project/admin/index.php")]
        [TestCase("abcdef", "Temp@2020", TestName = "Negative Scenario 1", ExpectedResult = " Error: Invalid administrator login attempt.")]
        [TestCase("gcreddy", "abcde@321", TestName = "Negative Scenario 2", ExpectedResult = " Error: The maximum number of login attempts has been reached. Please try again in 5 minutes.")]
        [TestCase("abcdef", "abcde@321", TestName = "Negative Scenario 3", ExpectedResult = " Error: The maximum number of login attempts has been reached. Please try again in 5 minutes.")]
        [TestCase("gcreddy", " ", TestName = "Negative Scenario 4", ExpectedResult = " Error: The maximum number of login attempts has been reached. Please try again in 5 minutes.")]
        [TestCase(" ", "Temp@2020", TestName = "Negative Scenario 5", ExpectedResult = " Error: The maximum number of login attempts has been reached. Please try again in 5 minutes.")]
        [TestCase(" ", " ", TestName = "Negative Scenario 6", ExpectedResult = " Error: The maximum number of login attempts has been reached. Please try again in 5 minutes.")]
        public string VerifyAdminLoginOrErrorMessageInLoginFunctionalityInGcrshopApplication(string username, string password)
        {
            loginPage.loginWith(username, password);

            string actualMessage = loginPage.getErrorMessage();

            return actualMessage;
        }
    }
}
