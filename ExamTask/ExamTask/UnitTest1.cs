using Aquality.Selenium.Browsers;
using ExamTask.ApiRequests;
using ExamTask.Models;
using ExamTask.Pages;
using ExamTask.Util;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ExamTask
{
    public class Tests : BaseTest
    {
        private SecondVariantRequests Requests = new SecondVariantRequests();
        private HomePage homePage = new HomePage();
        private Footer footer = new Footer();
        private ProjectPage projectPage = new ProjectPage();

        [Test]
        public void ExamTask()
        {
            (var Token, var StatusCode) = Requests.GetToken(ConfigClass.Config["Variant"]);
            Assert.AreEqual(StatusCode, "OK", "Status code is not 200.");
            Assert.IsNotEmpty(Token, "Token is empty");

            AqualityServices.Browser.Driver.Manage().Cookies.AddCookie(new Cookie("token", Token));
            AqualityServices.Browser.Refresh();
            Assert.IsTrue(homePage.State.IsEnabled, "Home page are not opened");
            Assert.IsTrue(footer.IsTaskVersionCorrect(ConfigClass.Config["Variant"]), "Task version is not correct");

            homePage.OpenProjectLink(ConfigClass.Config["Project"]);
            var Tests = projectPage.GetTestsList();
            List<TestsModel> AllTests = new List<TestsModel>();
            try
            {
                (AllTests, StatusCode) = Requests.GetProjectTests(ConfigClass.Config["ProjectId"]);
            }
            catch
            {
                Assert.Fail();
            }

            Assert.AreEqual(StatusCode, "OK", "Status code is not 200.");
            Assert.IsTrue(CompareUtil.IsTestsSortedByDate(Tests), "Tests is not sorted by date");
            Assert.IsTrue(CompareUtil.AreTestsContainsInList(Tests, AllTests), "Tests in UI is not exist in API Request");

            AqualityServices.Browser.GoBack();
        }
    }
}