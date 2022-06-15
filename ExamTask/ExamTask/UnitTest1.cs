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
        private AddProjectPage addProjectPage = new AddProjectPage();

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
                Assert.Fail("Response is not in JSON format");
            }

            Assert.AreEqual(StatusCode, "OK", "Status code is not 200.");
            Assert.IsTrue(CompareUtil.IsTestsSortedByDate(Tests), "Tests is not sorted by date");
            Assert.IsTrue(CompareUtil.AreTestsContainsInList(Tests, AllTests), "Tests in UI is not exist in API Request");

            AqualityServices.Browser.GoBack();
            homePage.ClickAddButton();
            AqualityServices.Browser.Tabs().SwitchToLastTab();
            addProjectPage.AddNewProject(ConfigClass.Config["NewProjectName"]);
            Assert.IsTrue(addProjectPage.IsAlertDisplayed(), "Message is not displayed");
            AqualityServices.Browser.ExecuteScript("window.self.close();");
            Assert.IsTrue(1 == AqualityServices.Browser.Tabs().TabHandles.Count && !addProjectPage.State.IsExist, "Add project tab is open");
            AqualityServices.Browser.Tabs().SwitchToTab(AqualityServices.Browser.Tabs().TabHandles[0]);
            AqualityServices.Browser.Refresh();
            Assert.IsTrue(homePage.IsProjectExist(ConfigClass.Config["NewProjectName"]), "Project is not added");
        }
    }
}