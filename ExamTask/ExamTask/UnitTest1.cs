using Aquality.Selenium.Browsers;
using ExamTask.ApiRequests;
using ExamTask.Comparers;
using ExamTask.Models;
using ExamTask.Pages;
using ExamTask.Util;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ExamTask
{
    public class Tests : BaseTest
    {
        private HomePage homePage = new HomePage();
        private Footer footer = new Footer();
        private ProjectPage projectPage = new ProjectPage();
        private AddProjectPage addProjectPage = new AddProjectPage();

        [Test]
        public void ReportingPortalTest()
        {
            AqualityServices.Logger.Info("Getting a token according to the variant number");
            (var Token, var StatusCode) = SecondVariantRequests.GetToken(ConfigClass.Config["Variant"]);
            Assert.AreEqual(StatusCode, "OK", "Status code is not 200.");
            Assert.IsNotEmpty(Token, "Token is empty");

            AqualityServices.Logger.Info("Passing a token to a cookie");
            AqualityServices.Browser.Driver.Manage().Cookies.AddCookie(new Cookie("token", Token));
            AqualityServices.Browser.Refresh();
            Assert.IsTrue(homePage.State.IsEnabled, "Home page are not opened");
            Assert.AreEqual($"Version: {ConfigClass.Config["Variant"]}", footer.GetTaskVersion(), "Task version is not correct");

            homePage.OpenProjectLink(ConfigClass.Config["Project"]);
            AqualityServices.Logger.Info("Getting a list of project tests");
            var Tests = projectPage.GetTestsList();
            List<TestsModel> AllTests = new List<TestsModel>();

            (AllTests, StatusCode) = SecondVariantRequests.GetProjectTests(ConfigClass.Config["ProjectId"]);
            if (StatusCode == null)
            {
                Assert.Fail("Response is not in JSON format");
            }
            Assert.AreEqual(StatusCode, "OK", "Status code is not 200.");
            CollectionAssert.IsOrdered(Tests, new TestComparer(), "Tests is not sorted by date");
            CollectionAssert.IsSubsetOf(Tests, AllTests, "Tests in UI is not exist in API Request");

            AqualityServices.Logger.Info("Adding a new project");
            AqualityServices.Browser.GoBack();
            homePage.ClickAddButton();
            AqualityServices.Browser.Tabs().SwitchToLastTab();
            addProjectPage.AddNewProject(ConfigClass.Config["NewProjectName"]);
            Assert.IsTrue(addProjectPage.IsAlertDisplayed(), "Message alert was not displayed");
            AqualityServices.Browser.ExecuteScript("window.self.close();");
            Assert.IsTrue(1 == AqualityServices.Browser.Tabs().TabHandles.Count && !addProjectPage.State.IsExist, "Add project tab is open");
            AqualityServices.Browser.Tabs().SwitchToTab(AqualityServices.Browser.Tabs().TabHandles[0]);
            AqualityServices.Browser.Refresh();
            Assert.IsTrue(homePage.IsProjectExist(ConfigClass.Config["NewProjectName"]), "Project is not added");

            AqualityServices.Logger.Info("Adding new tests for a new project");
            homePage.OpenProjectLink(ConfigClass.Config["NewProjectName"]);
            NewTestModel newTest = new NewTestModel()
            {
                SID = TextGenerator.GenerateText(),
                ProjectName = ConfigClass.Config["NewProjectName"],
                Env = TextGenerator.GenerateText(),
                MethodName = TextGenerator.GenerateText(),
                TestName = TextGenerator.GenerateText()
            };
            (var NewTestId, StatusCode) = SecondVariantRequests.AddNewTest(newTest);
            Assert.AreEqual(StatusCode, "OK", "Status code is not 200.");
            TestLogModel testLog = new TestLogModel()
            {
                TestId = NewTestId,
                Content = TextGenerator.GenerateText()
            };
            (var Log, StatusCode) = SecondVariantRequests.AddTestLog(testLog);
            Assert.AreEqual(StatusCode, "OK", "Status code is not 200.");
            var screenshotBytes = AqualityServices.Browser.GetScreenshot();
            var screenshot = Convert.ToBase64String(screenshotBytes);
            TestAttachmentModel testAttachment = new TestAttachmentModel()
            {
                TestId = NewTestId,
                Content = screenshot,
                ContentType = "image/png"
            };

            (var Attacment, StatusCode) = SecondVariantRequests.AddTestAttachment(testAttachment);
            if (StatusCode == null)
            {
                Assert.Fail("Failed to add attachment");
            }
            Assert.AreEqual(StatusCode, "OK", "Status code is not 200.");
            Assert.IsTrue(projectPage.IsTestExist(NewTestId), "Test is not added");
        }
    }
}